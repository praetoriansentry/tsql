using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Default : Interpreter
    {

        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            if (this.shouldCapitalize(pu.token.Value.Type))
            {
                return pu.token.Value.Text.ToUpper();
            }
            return pu.token.Value.Text;
        }


    }
}
