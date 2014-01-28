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
            string comment = pu.token.Value.Text;
            if (pu.token.Previous != null && pu.token.Value.Text != "LEX_END_OF_LINE_COMMENT")
            {
                //I want single comments to be on a line of their own
                comment = this.GetNewLine(pu) + comment;
            }
            if (pu.token.Next != null && pu.token.Next.Value.Text == "LEX_END_OF_LINE_COMMENT")
            {
                // if there is another comment, don't add a return at the end
                comment = this.GetNewLine(pu) + comment;
            }
            else
            {
                comment = this.GetNewLine(pu) + comment + this.GetNewLine(pu);
            }
            return comment;

        }
    }
}
