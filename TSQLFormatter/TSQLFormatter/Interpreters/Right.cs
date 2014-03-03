using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Right : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            if (this.IsJoin(pu))
            {
                return this.GetNewLine(pu) + this.GetNewLine(pu) + pu.token.Value.Text.ToUpper();

            }
            else
            {
                return pu.token.Value.Text.ToUpper();
            }
        }
        private Boolean IsJoin(Formatter.ParseUnit pu) {
            LinkedListNode<Token> currentToken = pu.token;

            for (int i = 0; i < 3; i = i + 1)
            {
                if (currentToken.Value.Type == "TOKEN_OUTER" || currentToken.Value.Type == "TOKEN_JOIN")
                {
                    return true; 
                }
                if (currentToken.Next != null)
                {
                    currentToken = currentToken.Next;
                }
                else
                {
                    break;
                }
            }
            return false;
        }
    }
}
