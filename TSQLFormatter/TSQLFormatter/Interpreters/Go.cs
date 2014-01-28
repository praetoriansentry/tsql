using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Go : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            // go statements reset a bunch of stuff
            pu.clauseStack.Clear();
            pu.indentDepth = 0;
            return this.GetNewLine(pu) + pu.token.Value.Text.ToUpper() + this.GetNewLine(pu);
        }
    }
}
