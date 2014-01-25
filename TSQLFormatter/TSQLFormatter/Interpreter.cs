using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

// Trying to model this after what I saw here:
// http://en.wikipedia.org/wiki/Interpreter_pattern

namespace TSQLFormatter
{
    abstract class Interpreter
    {
        public string Interpret(Formatter.ParseUnit pu)
        {
            return pu.token.Value.Text;
        }
    }
}
