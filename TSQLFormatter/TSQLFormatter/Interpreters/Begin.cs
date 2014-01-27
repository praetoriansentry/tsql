using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Begin : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            pu.clauseStack.Push(pu.token.Value);
            pu.indentDepth = pu.indentDepth + 1;
            return this.FormatOwnLine(pu);
        }
    }
}
