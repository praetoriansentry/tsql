using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter.Interpreters
{
    class Comma : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            Token t;
            try
            {
                t = pu.clauseStack.Peek();
            }
            catch (Exception)
            {
                return ",";
            }

            if (t.Type == "TOKEN_SELECT")
            {
                return "," + this.GetNewLine(pu);
            }
            return ",";
        }
    }
}
