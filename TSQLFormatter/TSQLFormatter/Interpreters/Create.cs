using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Create : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            pu.clauseStack.Clear();

            pu.indentDepth = 0;

            pu.clauseStack.Push(pu.token.Value);
            return this.GetNewLine(pu) + this.GetNewLine(pu) + pu.token.Value.Text.ToUpper();
        }
    }
}
