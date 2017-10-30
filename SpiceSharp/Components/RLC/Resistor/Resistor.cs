﻿using SpiceSharp.Circuits;
using SpiceSharp.Parameters;
using SpiceSharp.Sparse;

namespace SpiceSharp.Components
{
    /// <summary>
    /// A resistor
    /// </summary>
    [SpicePins("R+", "R-")]
    public class Resistor : CircuitComponent<Resistor>
    {
        /// <summary>
        /// Register default behaviours of the resistor
        /// </summary>
        static Resistor()
        {
            Behaviors.Behaviors.RegisterBehavior(typeof(Resistor), typeof(ComponentBehaviors.ResistorLoadBehavior));
            Behaviors.Behaviors.RegisterBehavior(typeof(Resistor), typeof(ComponentBehaviors.ResistorAcBehavior));
            Behaviors.Behaviors.RegisterBehavior(typeof(Resistor), typeof(ComponentBehaviors.ResistorNoiseBehavior));
            Behaviors.Behaviors.RegisterBehavior(typeof(Resistor), typeof(ComponentBehaviors.ResistorTemperatureBehavior));
        }

        /// <summary>
        /// Set the model for the resistor
        /// </summary>
        /// <param name="model"></param>
        public void SetModel(ResistorModel model) => Model = model;

        /// <summary>
        /// Parameters
        /// </summary>
        [SpiceName("temp"), SpiceInfo("Instance operating temperature", Interesting = false)]
        public double RES_TEMP
        {
            get => REStemp - Circuit.CONSTCtoK;
            set => REStemp.Set(value + Circuit.CONSTCtoK);
        }
        public Parameter REStemp { get; } = new Parameter(300.15);
        [SpiceName("resistance"), SpiceInfo("Resistance", IsPrincipal = true)]
        public Parameter RESresist { get; } = new Parameter();
        [SpiceName("w"), SpiceInfo("Width", Interesting = false)]
        public Parameter RESwidth { get; } = new Parameter();
        [SpiceName("l"), SpiceInfo("Length", Interesting = false)]
        public Parameter RESlength { get; } = new Parameter();
        [SpiceName("i"), SpiceInfo("Current")]
        public double GetCurrent(Circuit ckt) => (ckt.State.Real.Solution[RESposNode] - ckt.State.Real.Solution[RESnegNode]) * RESconduct;
        [SpiceName("p"), SpiceInfo("Power")]
        public double GetPower(Circuit ckt) => (ckt.State.Real.Solution[RESposNode] - ckt.State.Real.Solution[RESnegNode]) *
            (ckt.State.Real.Solution[RESposNode] - ckt.State.Real.Solution[RESnegNode]) * RESconduct;

        /// <summary>
        /// Nodes
        /// </summary>
        public int RESposNode { get; private set; }
        public int RESnegNode { get; private set; }

        internal MatrixElement RESposPosPtr;
        internal MatrixElement RESnegNegPtr;
        internal MatrixElement RESposNegPtr;
        internal MatrixElement RESnegPosPtr;

        /// <summary>
        /// Private variables
        /// </summary>
        internal double RESconduct = 0.0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the resistor</param>
        public Resistor(CircuitIdentifier name) : base(name) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the resistor</param>
        /// <param name="pos">The positive node</param>
        /// <param name="neg">The negative node</param>
        /// <param name="res">The resistance</param>
        public Resistor(CircuitIdentifier name, CircuitIdentifier pos, CircuitIdentifier neg, double res) : base(name)
        {
            Connect(pos, neg);
            RESresist.Set(res);
        }

        /// <summary>
        /// Setup the resistor
        /// </summary>
        /// <param name="ckt"></param>
        public override void Setup(Circuit ckt)
        {
            var nodes = BindNodes(ckt);
            RESposNode = nodes[0].Index;
            RESnegNode = nodes[1].Index;

            var state = ckt.State.Real;
            RESposPosPtr = state.Matrix.SMPmakeElt(RESposNode, RESposNode);
            RESnegNegPtr = state.Matrix.SMPmakeElt(RESnegNode, RESnegNode);
            RESposNegPtr = state.Matrix.SMPmakeElt(RESposNode, RESnegNode);
            RESnegPosPtr = state.Matrix.SMPmakeElt(RESnegNode, RESposNode);
        }
    }
}
