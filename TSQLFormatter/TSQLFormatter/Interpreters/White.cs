using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class White : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            Regex r = new Regex(@"\s$");
            if (r.IsMatch(pu.sqlBits.Last.Value)) {
                return "";
            }
            return " ";
        }
    }
}
