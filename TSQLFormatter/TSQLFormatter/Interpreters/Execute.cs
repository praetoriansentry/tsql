using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Execute : Interpreter
    {


        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            return this.FormatOwnLine(pu);
        }




    }
}
