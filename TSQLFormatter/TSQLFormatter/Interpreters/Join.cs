using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Join : Interpreter
    {
        public override string Interpret(Formatter.ParseUnit pu)
        {
            // Check to see if this join is on it's own.
            try {
                LinkedListNode<Token> t = pu.token;
                for(int i = 0; i < 3; i = i + 1) {
                    t = t.Previous;
                    if (t.Value.Type == "TOKEN_OUTER" || t.Value.Type == "TOKEN_LEFT" || t.Value.Type == "TOKEN_RIGHT") {
                        return pu.token.Value.Text.ToUpper() + this.GetNewLine(pu);
                    }
                }
            } catch (Exception e) {
            }
            return this.FormatOwnLine(pu);
        }
    }
}
