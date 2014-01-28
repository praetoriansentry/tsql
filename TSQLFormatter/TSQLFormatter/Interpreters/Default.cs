using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Default : Interpreter
    {


        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            if (this.IsToken(pu.token.Value))
            {
                Console.WriteLine(pu.token.Value.Type);
                return this.GetNewLine(pu) + pu.token.Value.Text.ToUpper();
            }
            if (this.shouldCapitalize(pu.token.Value.Type))
            {
                return pu.token.Value.Text.ToUpper();
            }
            return pu.token.Value.Text;
        }




    }
}
