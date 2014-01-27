using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;


namespace TSQLFormatter.Interpreters
{
    class White : Interpreter
    {
        protected static Regex wsCheck = new Regex(@"\s$");
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            Regex r = White.wsCheck;
            if (r.IsMatch(pu.sqlBits.Last.Value)) {
                return "";
            }
            if (pu.token.Next != null && this.needsManual(pu.token.Next.Value))
            {
                return "";
            }
            if (pu.token.Previous != null && this.needsManual(pu.token.Previous.Value))
            {
                return "";
            }
            return " ";
        }

        protected bool needsManual(Token t)
        {
            string[] manualTypes = {
                                       "(",
                                       ")",
                                       ",",
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
            return manualTypes.Contains(t.Type);
        }
    }
}
