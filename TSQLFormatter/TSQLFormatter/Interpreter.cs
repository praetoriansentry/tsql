using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;
using System.Text.RegularExpressions;

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
            if (this.shouldSingleReturn(pu))
            {
                return this.GetNewLine(pu) + pu.token.Value.Text.ToUpper() + this.GetNewLine(pu);
            }
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

        protected bool shouldSingleReturn(Formatter.ParseUnit pu)
        {
            LinkedListNode<Token> t = pu.token;
            for (int i = 0; i < 3; i = i + 1)
            {
                if (t.Previous == null)
                {
                    // there is nothing before the select statement... so we can just do the normal stuff and it will get trimmed off
                    return false;
                }
                if (t.Previous.Value.Type == "(" || t.Previous.Value.Type == "LEX_END_OF_LINE_COMMENT")
                {
                    return true;
                }
                t = t.Previous;
            }
            return false;
        }
        protected bool IsToken(Token t)
        {
            if (t.Type == "TOKEN_ID")
            {
                return false;
            }
            Regex r = new Regex(@"^TOKEN_.*");
            return r.IsMatch(t.Type);
        }
    }
}
