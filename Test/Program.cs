using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SpiceSharp;
using SpiceSharp.Behaviors;
using SpiceSharp.Components;
using SpiceSharp.Simulations;

namespace SpiceSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleDC();
        }


        private static void SampleDC()
        {
            DiodCreator diodCreator = new DiodCreator();

            var ckt = new Circuit(
                new VoltageSource("V1", "in", "0", 10),
                new Resistor("R1", "in", "out", 1.0e3)
                );

            // Добавление диода
            ckt.Add(new Diode("D1", "out", "0", "1N914"), 
                diodCreator.CreateDiodeModel("1N914", "Is=2.52e-9 Rs=0.568 N=1.752 Cjo=4e-12 M=0.4 tt=20e-9")); // Параметры из LTSpice

            var dc = new DC("dc", "V1", 0.0, 150.0, 1);

            dc.ExportSimulationData += (sender, exportDataEventArgs) =>
            {
                Console.WriteLine(exportDataEventArgs.GetVoltage("out")); ;
            };


            dc.Run(ckt);
        }


    }

    
}