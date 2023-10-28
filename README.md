# <img src="https://spicesharp.github.io/SpiceSharp/api/images/logo_full.svg" width="45px" /> Spice# (SpiceSharp)
Spice# — это симулятор схем Spice, написанный на языке C#. Платформа создана для совместимости с оригинальным симулятором Berkeley Spice, но в ней устранены многие ошибки.

В планах сделать поодержку AIFamework и AIDog, для реализации синтеза схем методами искусственного интеллекта

##  Быстрый старт
Моделировать принципиальную схема схему относительно просто. Например:

```csharp
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
    }
}
```

Доступно большинство стандартных компонентов Spice, а также возможно создание собственных компонентов!
