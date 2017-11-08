﻿using System;
using System.Numerics;
using System.Collections.Generic;
using System.Windows.Forms;
using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;
using SpiceSharp.Parameters;
using SpiceSharp.Parser.Readers;
using SpiceSharp.Diagnostics;
using MathNet.Numerics.Interpolation;
using SpiceSharp.Circuits;

namespace Sandbox
{
    public partial class Main : Form
    {
        public List<double> input = new List<double>();
        public List<double> output = new List<double>();

        /// <summary>
        /// Constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();

            Circuit ckt = new Circuit();
            ckt.Objects.Add(
            new Voltagesource("V2", "1", "2", 1),
            new Voltagesource("V1", "6", "gnd", 1),
            new Resistor("V1-R", "gnd", "1", 1),
            new Resistor("V2-R", "2", "3", 1),
            new Resistor("R", "1", "6", 1)
            );
            ckt.Check();
        }
    }
}