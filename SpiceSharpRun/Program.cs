using System;
using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;

namespace SpiceSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            DC();
        }

        private static void Sample()
        {
            // Build the circuit
            var ckt = new Circuit(
                new VoltageSource("V1", "in", "0", 0.0),
                new Resistor("R1", "in", "out", 1.0e3),
                new Resistor("R2", "out", "0", 2.0e3)
                );

            // Create a DC sweep and register to the event for exporting simulation data
            var dc = new DC("dc", "V1", 0.0, 5.0, 0.001);
            dc.ExportSimulationData += (sender, exportDataEventArgs) =>
            {
                Console.WriteLine(exportDataEventArgs.GetVoltage("out"));
            };

            // Run the simulation
            dc.Run(ckt);
        }

        public static void DC()
        {
            // Build the circuit
            var ckt = new Circuit(
                new VoltageSource("V1", "in", "0", 5.0),
                new Resistor("R1", "in", "out", 1.0e3),
                new Resistor("R2", "out", "0", 2.0e3)
                );
            // Create an Operating Point simulation
            var dc = new OP("my op");
            Export<double> currentExport = new RealPropertyExport(dc, "R1", "i");
            dc.ExportSimulationData += (sender, exportDataEventArgs) =>
            {
                double voltage = exportDataEventArgs.GetVoltage("out");
                double current = currentExport.Value;
                Console.WriteLine($"Out: {voltage} V, Current: {current} A");
            };
            // Run the simulation
            dc.Run(ckt);

            // Per Sven: The simulation searches for the Operating Point of the circuit, 
            // which is the DC solution to the circuit without sweeping any parameters.            
        }
    }
}