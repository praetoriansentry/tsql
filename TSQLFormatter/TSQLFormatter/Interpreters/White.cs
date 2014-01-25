using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class White : Interpreter
    {
        public string Interpret(Formatter.ParseUnit pu)
        {
            return " ";
        }
    }
}
