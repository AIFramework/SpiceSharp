using AI.DataStructs.Algebraic;
using SpiceSharp;
using SpiceSharp.Circuits;
using SpiceSharp.Components;
using SpiceSharp.Simulations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowPass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            circuit = CreateCrk(n_blocks: 3, c1: 2.5e-6, c2: 1.3e-6); // Фильтр 6 порядка
        }

        Circuit circuit;
        int max_block;


        double CalcDenom(double fCut, double r) 
        {
            return Math.PI * 2 * fCut * r;
        }

        double CalcC1(double fCut, double r)
        {
            return 1.114 / CalcDenom(fCut, r);
        }

        double CalcC2(double fCut, double r)
        {
            return 0.707 / CalcDenom(fCut, r);
        }

        // Параметры одного блока ФНЧ
        Entity[] FilterBlockFromParam(double c1 = 1.44e-6, double c2 = 1.09e-6, double inpC = 1e-6, double r=1e+3, int n_block =1)
        {
            //Транзистор
            var bPolar = new Mosfet1("M1_"+n_block) { Model = "bPolar" };
            bPolar.Connect("E", "m3_" + n_block, "out_" + n_block, "out_" + n_block);

            Entity[] block =
            {
               new Capacitor("C_"+n_block, "out_"+(n_block-1), "m_"+n_block, inpC),
               new Resistor("R1_"+n_block, "E", "m_"+n_block, 1.0e+4),
               new Resistor("R2_"+n_block, "m_"+n_block, "0", 1.0e+4),

               new Resistor("R3_"+n_block, "m_"+n_block, "m2_"+n_block, r),
               new Resistor("R4_"+n_block, "m2_"+n_block, "m3_"+n_block, r),

               new Capacitor("C1_"+n_block, "m2_"+n_block, "out_"+n_block, c1),
               new Capacitor("C2_"+n_block, "m3_"+n_block, "0", c2),
               new Resistor("R5_"+n_block, "0", "out_"+n_block, 5.6e+3),
               bPolar
            };

            return block;
        }

        // Много блоков
        Circuit CreateCrk(double c1 = 1.44e-6, double c2 = 1.09e-6, double inpC = 1000e-6, double r = 1e+3, int n_blocks = 1) 
        {
            // Создание модели транзистора
            var bPolar_model = new Mosfet1Model("bPolar");
            bPolar_model.SetParameter("kp", 150.0e-3);

            max_block = n_blocks;
            Circuit crk = new Circuit();

            for (int i = 0; i < n_blocks; i++)
            {
                Entity[] entities = FilterBlockFromParam(c1, c2, inpC, r, i+1);
                for (int j = 0; j < entities.Length; j++)
                {
                    crk.Add(entities[j]);
                }
            }

            crk.Add(new VoltageSource("V1", "E", "0", 5)); // Питание
            crk.Add(new VoltageSource("V2", "out_0", "0", 0)); // Сигнал
            crk.Add(bPolar_model); // Транзистор

            return crk;
        }



        /// <summary>
        /// Анализ по переменному току
        /// </summary>
        private void ACAnalyzer(Circuit ckt, AC ac, string vSource = "V2")
        {

            foreach (var item in ckt)
            {
                if (item.Name == vSource)
                {
                    item.SetParameter("acmag", 1.0);
                }
            }

            var exportVoltage = new ComplexVoltageExport(ac, "out_"+max_block);
            var exportVoltageIn = new ComplexVoltageExport(ac, "out_0");
            Vector k = new Vector(0);
            Vector f = new Vector(0);

            ac.ExportSimulationData += (sender, exportDataEventArgs) =>
            {
                var output = exportVoltage.Value.Magnitude;
                var input = exportVoltageIn.Value.Magnitude;
                var K = output / input;
                k.Add(K);
                f.Add(exportDataEventArgs.Frequency);
                
                if(f.Count == 900) chartVisual1.PlotBlack(f, k);
            };


            ac.Run(ckt);
        }









        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(order.Text) / 2;
            double fCut = Convert.ToDouble(freqCut.Text, AI.AISettings.GetProvider());
            double c1 = CalcC1(fCut, 1e3);
            double c2 = CalcC2(fCut, 1e3);

            C3l.Text = "C3 = "+ Math.Round(c1 *1e6, 3) +" мкФ";
            C2l.Text = "C2 = "+ Math.Round(c2 * 1e6, 3) + " мкФ";
            nC.Text = "Число каскадов: " + n;


            circuit = CreateCrk(n_blocks: n, c1:c1, c2: c2); // Фильтр заданного порядка

            var ac = new AC("ac", new LinearSweep(0, 2* fCut, 1000)); // Анализатор
            ACAnalyzer(circuit, ac);
        }
    }
}
