using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

// Trying to model this after what I saw here:
// http://en.wikipedia.org/wiki/Interpreter_pattern

namespace TSQLFormatter
{
    abstract class Interpreter
    {
        protected string indentString = "    ";

        public virtual string Interpret(ref Formatter.ParseUnit pu)
        {
            return pu.token.Value.Text;
        }

        protected string GetNewLine(Formatter.ParseUnit pu) {
            string newLine = "";
            for (int i = 0; i < pu.indentDepth; i = i + 1)
            {
                newLine = newLine + this.indentString;
            }
            return Environment.NewLine + newLine;
        }

        protected string FormatOwnLine(Formatter.ParseUnit pu)
        {
            return this.GetNewLine(pu) + this.GetNewLine(pu) + pu.token.Value.Text.ToUpper() + this.GetNewLine(pu);
        }
        protected bool shouldCapitalize(string tokenType)
        {
            string[] typesToLeaveAlone = {
                                             "TOKEN_ID",
                                             "TOKEN_STRING",
                                             "TOKEN_VARIABLE"
                                         };
            if (typesToLeaveAlone.Contains(tokenType))
            {
                return false;
            }
            return true;
        }
    }
}
