using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter.Interpreters
{
    class Paren : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            if (pu.token.Value.Type == "(")
            {
                pu.clauseStack.Push(pu.token.Value);
            }
            else
            {
                pu.clauseStack.Pop();
            }

            return pu.token.Value.Text;
        }
    }
}
