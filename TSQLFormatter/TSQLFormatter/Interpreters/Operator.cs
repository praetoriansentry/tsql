using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Operator : Interpreter
    {
        public static string[] operators = {
                                       "%",
                                       "+",
                                       "-",
                                       "/",
                                       "*",
                                       "<",
                                       ">",
                                       "=",
                                       "&",
                                       "|",
                                       "^",
                                       "!"
                                           };
        public override string Interpret(ref Formatter.ParseUnit pu)
        {

            // TODO this needs to be changed so that if there is already white space around the token, we don't add more.
            if (pu.token.Previous != null && Operator.operators.Contains(pu.token.Previous.Value.Type))
            {
                return pu.token.Value.Text + " ";
            }
            else if (pu.token.Next != null && Operator.operators.Contains(pu.token.Next.Value.Type))
            {
                return " " + pu.token.Value.Text;
            }
            return " " + pu.token.Value.Text + " ";
        }
    }
}
