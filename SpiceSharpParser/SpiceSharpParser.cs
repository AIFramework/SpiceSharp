/* Generated By:CSharpCC: Do not edit this line. SpiceSharpParser.cs */
using System;
using System.Collections.Generic;
using SpiceSharp.Parser.Readers;

namespace SpiceSharp.Parser
{
    /// <summary>
    /// Spice parser
    /// This class is generated by CSharpCC (a port of JavaCC to C#). Refer to spicelang.cc for the syntax.
    /// </summary>
    public class SpiceSharpParser : SpiceSharpParserConstants
    {

        public StatementsToken ParseNetlist(Netlist netlist)
        {
            Statement st;
            StatementsToken body = new StatementsToken();
            while (true)
            {
                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                {
                    case DOT:
                    case NEWLINE:
                    case WORD:
                        break;
                    default:
                        mcc_la1[0] = mcc_gen;
                        goto label_1;
                }
                st = ParseSpiceLine();
                if (st != null)
                    body.Add(st);
            }
            label_1:;

            switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
            {
                case END:
                    mcc_consume_token(END);
                    break;
                case 0:
                    mcc_consume_token(0);
                    break;
                default:
                    mcc_la1[1] = mcc_gen;
                    mcc_consume_token(-1);
                    throw new ParseException();
            }
            { return body; }
            throw new Exception("Missing return statement in function");
        }

        public Statement ParseSpiceLine()
        {
            Statement st;
            Token t, tn;
            List<Token> parameters = new List<Token>();
            StatementsToken body;
            List<Statement> statements = new List<Statement>();
            switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
            {
                case WORD:
                    // Component definitions
                    tn = mcc_consume_token(WORD);
                    while (true)
                    {
                        switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                        {
                            case VALUE:
                            case STRING:
                            case EXPRESSION:
                            case REFERENCE:
                            case WORD:
                            case IDENTIFIER:
                                ;
                                break;
                            default:
                                mcc_la1[2] = mcc_gen;
                                goto label_2;
                        }
                        t = ParseParameter();
                        parameters.Add(t);
                    }
                    label_2:;

                    switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                    {
                        case NEWLINE:
                            mcc_consume_token(NEWLINE);
                            break;
                        case 0:
                            mcc_consume_token(0);
                            break;
                        default:
                            mcc_la1[3] = mcc_gen;
                            mcc_consume_token(-1);
                            throw new ParseException();
                    }
                    {
                        return new Statement(StatementType.Component, tn, parameters);
                    }
                default:
                    mcc_la1[12] = mcc_gen;
                    if (mcc_2_1(2))
                    {
                        mcc_consume_token(DOT);
                        tn = mcc_consume_token(1);
                        while (true)
                        {
                            switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                            {
                                case VALUE:
                                case STRING:
                                case EXPRESSION:
                                case REFERENCE:
                                case WORD:
                                case IDENTIFIER:
                                    ;
                                    break;
                                default:
                                    mcc_la1[4] = mcc_gen;
                                    goto label_3;
                            }
                            t = ParseParameter();
                            parameters.Add(t);
                        }
                        label_3:;

                        mcc_consume_token(NEWLINE);
                        body = new StatementsToken();
                        while (true)
                        {
                            switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                            {
                                case DOT:
                                case NEWLINE:
                                case WORD:
                                    ;
                                    break;
                                default:
                                    mcc_la1[5] = mcc_gen;
                                    goto label_4;
                            }
                            st = ParseSpiceLine();
                            if (st != null) body.Add(st);
                        }
                        label_4:;

                        mcc_consume_token(ENDS);
                        switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                        {
                            case WORD:
                                mcc_consume_token(WORD);
                                break;
                            default:
                                mcc_la1[6] = mcc_gen;
                                ;
                                break;
                        }
                        switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                        {
                            case NEWLINE:
                                mcc_consume_token(NEWLINE);
                                break;
                            case 0:
                                mcc_consume_token(0);
                                break;
                            default:
                                mcc_la1[7] = mcc_gen;
                                mcc_consume_token(-1);
                                throw new ParseException();
                        }
                        parameters.Add(body);
                        { return new Statement(StatementType.Subcircuit, tn, parameters); }
                    }
                    else if (mcc_2_2(2))
                    {
                        mcc_consume_token(DOT);
                        tn = mcc_consume_token(2);
                        while (true)
                        {
                            switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                            {
                                case VALUE:
                                case STRING:
                                case EXPRESSION:
                                case REFERENCE:
                                case WORD:
                                case IDENTIFIER:
                                    ;
                                    break;
                                default:
                                    mcc_la1[8] = mcc_gen;
                                    goto label_5;
                            }
                            t = ParseParameter();
                            parameters.Add(t);
                        }
                        label_5:;

                        switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                        {
                            case NEWLINE:
                                mcc_consume_token(NEWLINE);
                                break;
                            case 0:
                                mcc_consume_token(0);
                                break;
                            default:
                                mcc_la1[9] = mcc_gen;
                                mcc_consume_token(-1);
                                throw new ParseException();
                        }
                        if (parameters.Count < 2)
                        { throw new ParseException(tn, "At least a name and model type expected", false); }
                        tn = parameters[0];
                        parameters.RemoveAt(0);
                        { return new Statement(StatementType.Model, tn, parameters); }
                    }
                    else
                    {
                        switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                        {
                            case DOT:
                                mcc_consume_token(DOT);
                                tn = mcc_consume_token(WORD);
                                while (true)
                                {
                                    switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                                    {
                                        case VALUE:
                                        case STRING:
                                        case EXPRESSION:
                                        case REFERENCE:
                                        case WORD:
                                        case IDENTIFIER:
                                            ;
                                            break;
                                        default:
                                            mcc_la1[10] = mcc_gen;
                                            goto label_6;
                                    }
                                    t = ParseParameter();
                                    parameters.Add(t);
                                }
                                label_6:;

                                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                                {
                                    case NEWLINE:
                                        mcc_consume_token(NEWLINE);
                                        break;
                                    case 0:
                                        mcc_consume_token(0);
                                        break;
                                    default:
                                        mcc_la1[11] = mcc_gen;
                                        mcc_consume_token(-1);
                                        throw new ParseException();
                                }
                                return new Statement(StatementType.Control, tn, parameters);
                            case NEWLINE:
                                mcc_consume_token(NEWLINE);
                                return null;
                            default:
                                mcc_la1[13] = mcc_gen;
                                mcc_consume_token(-1);
                                throw new ParseException();
                        }
                    }
            }
            throw new Exception("Missing return statement in function");
        }

        public Token ParseParameter()
        {
            Token ta, tb;
            List<Token> tokens = new List<Token>();
            if (mcc_2_3(2))
            {
                ta = ParseSingle();
                mcc_consume_token(3);
                while (true)
                {
                    switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                    {
                        case VALUE:
                        case STRING:
                        case EXPRESSION:
                        case REFERENCE:
                        case WORD:
                        case IDENTIFIER:
                            ;
                            break;
                        default:
                            mcc_la1[14] = mcc_gen;
                            goto label_7;
                    }
                    tb = ParseParameter();
                    tokens.Add(tb);
                }
                label_7:;

                mcc_consume_token(4);
                ta = new BracketToken(ta, '(', tokens.ToArray());
                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                {
                    case 5:
                        mcc_consume_token(5);
                        tb = ParseSingle();
                        return new AssignmentToken(ta, tb);
                    default:
                        mcc_la1[15] = mcc_gen;
                        break;
                }
                { return ta; }
            }
            else if (mcc_2_4(2))
            {
                ta = ParseSingle();
                mcc_consume_token(6);
                while (true)
                {
                    switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                    {
                        case VALUE:
                        case STRING:
                        case EXPRESSION:
                        case REFERENCE:
                        case WORD:
                        case IDENTIFIER:
                            ;
                            break;
                        default:
                            mcc_la1[16] = mcc_gen;
                            goto label_8;
                    }
                    tb = ParseParameter();
                    tokens.Add(tb);
                }
                label_8:;

                mcc_consume_token(7);
                ta = new BracketToken(ta, '[', tokens.ToArray());
                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                {
                    case 5:
                        mcc_consume_token(5);
                        tb = ParseSingle();
                        return new AssignmentToken(ta, tb);
                    default:
                        mcc_la1[17] = mcc_gen;
                        break;
                }
                { return ta; }
            }
            else if (mcc_2_5(2))
            {
                ta = ParseSingle();
                mcc_consume_token(5);
                tb = ParseSingle();
                return new AssignmentToken(ta, tb);
            }
            else
            {
                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                {
                    case VALUE:
                    case STRING:
                    case EXPRESSION:
                    case REFERENCE:
                    case WORD:
                    case IDENTIFIER:
                        ta = ParseSingle();
                        return ta;
                    default:
                        mcc_la1[18] = mcc_gen;
                        mcc_consume_token(-1);
                        throw new ParseException();
                }
            }
            throw new Exception("Missing return statement in function");
        }

        public Token ParseSingle()
        {
            Token t;
            List<Token> ts = new List<Token>();
            switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
            {
                case WORD:
                    t = mcc_consume_token(WORD);
                    break;
                case VALUE:
                    t = mcc_consume_token(VALUE);
                    break;
                case STRING:
                    t = mcc_consume_token(STRING);
                    break;
                case IDENTIFIER:
                    t = mcc_consume_token(IDENTIFIER);
                    break;
                case REFERENCE:
                    t = mcc_consume_token(REFERENCE);
                    break;
                case EXPRESSION:
                    t = mcc_consume_token(EXPRESSION);
                    break;
                default:
                    mcc_la1[19] = mcc_gen;
                    mcc_consume_token(-1);
                    throw new ParseException();
            }
            ts.Add(t);
            while (true)
            {
                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                {
                    case COMMA:
                        ;
                        break;
                    default:
                        mcc_la1[20] = mcc_gen;
                        goto label_9;
                }
                mcc_consume_token(COMMA);
                switch ((mcc_ntk == -1) ? mcc_mntk() : mcc_ntk)
                {
                    case WORD:
                        t = mcc_consume_token(WORD);
                        break;
                    case VALUE:
                        t = mcc_consume_token(VALUE);
                        break;
                    case STRING:
                        t = mcc_consume_token(STRING);
                        break;
                    case IDENTIFIER:
                        t = mcc_consume_token(IDENTIFIER);
                        break;
                    case REFERENCE:
                        t = mcc_consume_token(REFERENCE);
                        break;
                    case EXPRESSION:
                        t = mcc_consume_token(EXPRESSION);
                        break;
                    default:
                        mcc_la1[21] = mcc_gen;
                        mcc_consume_token(-1);
                        throw new ParseException();
                }
                ts.Add(t);
            }
            label_9:;

            if (ts.Count > 1)
            { return new VectorToken(ts.ToArray()); }
            else
            { return ts[0]; }
            throw new Exception("Missing return statement in function");
        }

        private bool mcc_2_1(int xla)
        {
            mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
            try { return !mcc_3_1(); }
            catch (LookaheadSuccess) { return true; }
            finally { mcc_save(0, xla); }
        }

        private bool mcc_2_2(int xla)
        {
            mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
            try { return !mcc_3_2(); }
            catch (LookaheadSuccess) { return true; }
            finally { mcc_save(1, xla); }
        }

        private bool mcc_2_3(int xla)
        {
            mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
            try { return !mcc_3_3(); }
            catch (LookaheadSuccess) { return true; }
            finally { mcc_save(2, xla); }
        }

        private bool mcc_2_4(int xla)
        {
            mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
            try { return !mcc_3_4(); }
            catch (LookaheadSuccess) { return true; }
            finally { mcc_save(3, xla); }
        }

        private bool mcc_2_5(int xla)
        {
            mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
            try { return !mcc_3_5(); }
            catch (LookaheadSuccess) { return true; }
            finally { mcc_save(4, xla); }
        }

        private bool mcc_3R_11()
        {
            if (mcc_scan_token(COMMA)) return true;
            return false;
        }

        private bool mcc_3_5()
        {
            if (mcc_3R_10()) return true;
            if (mcc_scan_token(5)) return true;
            return false;
        }

        private bool mcc_3_2()
        {
            if (mcc_scan_token(DOT)) return true;
            if (mcc_scan_token(2)) return true;
            return false;
        }

        private bool mcc_3_1()
        {
            if (mcc_scan_token(DOT)) return true;
            if (mcc_scan_token(1)) return true;
            return false;
        }

        private bool mcc_3R_10()
        {
            Token xsp;
            xsp = mcc_scanpos;
            if (mcc_scan_token(23))
            {
                mcc_scanpos = xsp;
                if (mcc_scan_token(19))
                {
                    mcc_scanpos = xsp;
                    if (mcc_scan_token(20))
                    {
                        mcc_scanpos = xsp;
                        if (mcc_scan_token(24))
                        {
                            mcc_scanpos = xsp;
                            if (mcc_scan_token(22))
                            {
                                mcc_scanpos = xsp;
                                if (mcc_scan_token(21)) return true;
                            }
                        }
                    }
                }
            }
            while (true)
            {
                xsp = mcc_scanpos;
                if (mcc_3R_11()) { mcc_scanpos = xsp; break; }
            }
            return false;
        }

        private bool mcc_3_4()
        {
            if (mcc_3R_10()) return true;
            if (mcc_scan_token(6)) return true;
            return false;
        }

        private bool mcc_3_3()
        {
            if (mcc_3R_10()) return true;
            if (mcc_scan_token(3)) return true;
            return false;
        }

        public SpiceSharpParserTokenManager token_source;
        SimpleCharStream mcc_input_stream;
        public Token token, mcc_nt;
        private int mcc_ntk;
        private Token mcc_scanpos, mcc_lastpos;
        private int mcc_la;
        public bool lookingAhead = false;
        private int mcc_gen;
        private int[] mcc_la1 = new int[22];
        static private int[] mcc_la1_0;
        static SpiceSharpParser()
        {
            mcc_gla1_0();
        }
        private static void mcc_gla1_0()
        {
            mcc_la1_0 = new int[] { 8462336, 262145, 33030144, 65537, 33030144, 8462336, 8388608, 65537, 33030144, 65537, 33030144, 65537, 8388608, 73728, 33030144, 32, 33030144, 32, 33030144, 33030144, 16384, 33030144, };
        }
        private MccCalls[] mcc_2_rtns = new MccCalls[5];
        private bool mcc_rescan = false;
        private int mcc_gc = 0;

        public SpiceSharpParser(System.IO.Stream stream)
        {
            mcc_input_stream = new SimpleCharStream(stream, 1, 1);
            token_source = new SpiceSharpParserTokenManager(mcc_input_stream);
            token = new Token();
            mcc_ntk = -1;
            mcc_gen = 0;
            for (int i = 0; i < 22; i++) mcc_la1[i] = -1;
            for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
        }

        public void ReInit(System.IO.Stream stream)
        {
            mcc_input_stream.ReInit(stream, 1, 1);
            token_source.ReInit(mcc_input_stream);
            token = new Token();
            mcc_ntk = -1;
            mcc_gen = 0;
            for (int i = 0; i < 22; i++) mcc_la1[i] = -1;
            for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
        }

        public SpiceSharpParser(System.IO.TextReader stream)
        {
            mcc_input_stream = new SimpleCharStream(stream, 1, 1);
            token_source = new SpiceSharpParserTokenManager(mcc_input_stream);
            token = new Token();
            mcc_ntk = -1;
            mcc_gen = 0;
            for (int i = 0; i < 22; i++) mcc_la1[i] = -1;
            for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
        }

        public void ReInit(System.IO.TextReader stream)
        {
            mcc_input_stream.ReInit(stream, 1, 1);
            token_source.ReInit(mcc_input_stream);
            token = new Token();
            mcc_ntk = -1;
            mcc_gen = 0;
            for (int i = 0; i < 22; i++) mcc_la1[i] = -1;
            for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
        }

        public SpiceSharpParser(SpiceSharpParserTokenManager tm)
        {
            token_source = tm;
            token = new Token();
            mcc_ntk = -1;
            mcc_gen = 0;
            for (int i = 0; i < 22; i++) mcc_la1[i] = -1;
            for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
        }

        public void ReInit(SpiceSharpParserTokenManager tm)
        {
            token_source = tm;
            token = new Token();
            mcc_ntk = -1;
            mcc_gen = 0;
            for (int i = 0; i < 22; i++) mcc_la1[i] = -1;
            for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
        }

        private Token mcc_consume_token(int kind)
        {
            Token oldToken = null;
            if ((oldToken = token).next != null) token = token.next;
            else token = token.next = token_source.GetNextToken();
            mcc_ntk = -1;
            if (token.kind == kind)
            {
                mcc_gen++;
                if (++mcc_gc > 100)
                {
                    mcc_gc = 0;
                    for (int i = 0; i < mcc_2_rtns.Length; i++)
                    {
                        MccCalls c = mcc_2_rtns[i];
                        while (c != null)
                        {
                            if (c.gen < mcc_gen) c.first = null;
                            c = c.next;
                        }
                    }
                }
                return token;
            }
            token = oldToken;
            mcc_kind = kind;
            throw GenerateParseException();
        }

        private class LookaheadSuccess : System.Exception { }
        private LookaheadSuccess mcc_ls = new LookaheadSuccess();
        private bool mcc_scan_token(int kind)
        {
            if (mcc_scanpos == mcc_lastpos)
            {
                mcc_la--;
                if (mcc_scanpos.next == null)
                {
                    mcc_lastpos = mcc_scanpos = mcc_scanpos.next = token_source.GetNextToken();
                }
                else
                {
                    mcc_lastpos = mcc_scanpos = mcc_scanpos.next;
                }
            }
            else
            {
                mcc_scanpos = mcc_scanpos.next;
            }
            if (mcc_rescan)
            {
                int i = 0; Token tok = token;
                while (tok != null && tok != mcc_scanpos) { i++; tok = tok.next; }
                if (tok != null) mcc_add_error_token(kind, i);
            }
            if (mcc_scanpos.kind != kind) return true;
            if (mcc_la == 0 && mcc_scanpos == mcc_lastpos) throw mcc_ls;
            return false;
        }

        public Token GetNextToken()
        {
            if (token.next != null) token = token.next;
            else token = token.next = token_source.GetNextToken();
            mcc_ntk = -1;
            mcc_gen++;
            return token;
        }

        public Token GetToken(int index)
        {
            Token t = lookingAhead ? mcc_scanpos : token;
            for (int i = 0; i < index; i++)
            {
                if (t.next != null) t = t.next;
                else t = t.next = token_source.GetNextToken();
            }
            return t;
        }

        private int mcc_mntk()
        {
            if ((mcc_nt = token.next) == null)
                return (mcc_ntk = (token.next = token_source.GetNextToken()).kind);
            else
                return (mcc_ntk = mcc_nt.kind);
        }

        private System.Collections.ArrayList mcc_expentries = new System.Collections.ArrayList();
        private int[] mcc_expentry;
        private int mcc_kind = -1;
        private int[] mcc_lasttokens = new int[100];
        private int mcc_endpos;

        private void mcc_add_error_token(int kind, int pos)
        {
            if (pos >= 100) return;
            if (pos == mcc_endpos + 1)
            {
                mcc_lasttokens[mcc_endpos++] = kind;
            }
            else if (mcc_endpos != 0)
            {
                mcc_expentry = new int[mcc_endpos];
                for (int i = 0; i < mcc_endpos; i++)
                {
                    mcc_expentry[i] = mcc_lasttokens[i];
                }
                bool exists = false;
                for (System.Collections.IEnumerator e = mcc_expentries.GetEnumerator(); e.MoveNext();)
                {
                    int[] oldentry = (int[])e.Current;
                    if (oldentry.Length == mcc_expentry.Length)
                    {
                        exists = true;
                        for (int i = 0; i < mcc_expentry.Length; i++)
                        {
                            if (oldentry[i] != mcc_expentry[i])
                            {
                                exists = false;
                                break;
                            }
                        }
                        if (exists) break;
                    }
                }
                if (!exists) mcc_expentries.Add(mcc_expentry);
                if (pos != 0) mcc_lasttokens[(mcc_endpos = pos) - 1] = kind;
            }
        }

        public ParseException GenerateParseException()
        {
            mcc_expentries.Clear();
            bool[] la1tokens = new bool[29];
            for (int i = 0; i < 29; i++)
            {
                la1tokens[i] = false;
            }
            if (mcc_kind >= 0)
            {
                la1tokens[mcc_kind] = true;
                mcc_kind = -1;
            }
            for (int i = 0; i < 22; i++)
            {
                if (mcc_la1[i] == mcc_gen)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if ((mcc_la1_0[i] & (1 << j)) != 0)
                        {
                            la1tokens[j] = true;
                        }
                    }
                }
            }
            for (int i = 0; i < 29; i++)
            {
                if (la1tokens[i])
                {
                    mcc_expentry = new int[1];
                    mcc_expentry[0] = i;
                    mcc_expentries.Add(mcc_expentry);
                }
            }
            mcc_endpos = 0;
            mcc_rescan_token();
            mcc_add_error_token(0, 0);
            int[][] exptokseq = new int[mcc_expentries.Count][];
            for (int i = 0; i < mcc_expentries.Count; i++)
            {
                exptokseq[i] = (int[])mcc_expentries[i];
            }
            return new ParseException(token, exptokseq, tokenImage);
        }

        private void mcc_rescan_token()
        {
            mcc_rescan = true;
            for (int i = 0; i < 5; i++)
            {
                MccCalls p = mcc_2_rtns[i];
                do
                {
                    if (p.gen > mcc_gen)
                    {
                        mcc_la = p.arg; mcc_lastpos = mcc_scanpos = p.first;
                        switch (i)
                        {
                            case 0: mcc_3_1(); break;
                            case 1: mcc_3_2(); break;
                            case 2: mcc_3_3(); break;
                            case 3: mcc_3_4(); break;
                            case 4: mcc_3_5(); break;
                        }
                    }
                    p = p.next;
                } while (p != null);
            }
            mcc_rescan = false;
        }

        private void mcc_save(int index, int xla)
        {
            MccCalls p = mcc_2_rtns[index];
            while (p.gen > mcc_gen)
            {
                if (p.next == null) { p = p.next = new MccCalls(); break; }
                p = p.next;
            }
            p.gen = mcc_gen + xla - mcc_la; p.first = token; p.arg = xla;
        }

        class MccCalls
        {
            public int gen;
            public Token first;
            public int arg;
            public MccCalls next;
        }

    }
}
