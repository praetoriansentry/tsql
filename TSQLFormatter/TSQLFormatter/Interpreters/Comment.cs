using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Comment : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            if (pu.token.Next != null && pu.token.Next.Value.Text == "LEX_END_OF_LINE_COMMENT")
            {
                return this.GetNewLine(pu) + pu.token.Value.Text;

            }
            return this.GetNewLine(pu) + pu.token.Value.Text + this.GetNewLine(pu);
        }
    }
}
