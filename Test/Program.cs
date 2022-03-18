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
            // Схема
            var ckt = new Circuit(
               new VoltageSource("V1", "in", "0", 0),
               new Resistor("R1", "in", "out", 1.0e3),
               new Inductor("L1", "out", "0", 1e-3),
               new Capacitor("C1", "out", "0", 1.0e-6),
               new Resistor("R2", "out", "0", 1e+5)
               );

            var ac = new AC("ac", new LinearSweep(1e+3, 6e+3, 1000)); // Анализатор

            // Анализ по переменному току
            ACAnalyzer(ckt, ac);

        }

        /// <summary>
        /// Анализ по переменному току
        /// </summary>
        private static void ACAnalyzer(Circuit ckt, AC ac, string vSource = "V1")
        {

            foreach (var item in ckt)
            {
                if (item.Name == vSource)
                {
                    item.SetParameter("acmag", 1.0);
                }
            }

            var exportVoltage = new ComplexVoltageExport(ac, "out");
            var exportVoltageIn = new ComplexVoltageExport(ac, "in");

            ac.ExportSimulationData += (sender, exportDataEventArgs) =>
            {
                var output = exportVoltage.Value.Magnitude;
                var input = exportVoltageIn.Value.Magnitude;
                var K = output / input;
                Console.WriteLine($"Коэф. передачи: {K},\t\t Частота: {exportDataEventArgs.Frequency}");
            };


            ac.Run(ckt);
        }


        //private static void DCAnalyzer()
        //{
        //    DiodCreator diodCreator = new DiodCreator();

        //    var ckt = new Circuit(
        //        new VoltageSource("V1", "in", "0", 10),
        //        new Resistor("R1", "in", "out", 1.0e3)
        //        );

        //    // Добавление диода
        //    ckt.Add(new Diode("D1", "out", "0", "1N914"),
        //        diodCreator.CreateDiodeModel("1N914", "Is=2.52e-9 Rs=0.568 N=1.752 Cjo=4e-12 M=0.4 tt=20e-9")); // Параметры из LTSpice

        //    var dc = new DC("dc", "V1", 0.0, 150.0, 1);

        //    dc.ExportSimulationData += (sender, exportDataEventArgs) =>
        //    {
        //        Console.WriteLine(exportDataEventArgs.GetVoltage("out")); ;
        //    };


        //    dc.Run(ckt);
        //}



    }

    
}