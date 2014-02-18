using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter.Interpreters
{
    class Semicolon : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {

            return ";" + this.GetNewLine(pu);
        }
    }
}
