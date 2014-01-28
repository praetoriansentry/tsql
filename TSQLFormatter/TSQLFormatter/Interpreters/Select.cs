using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Select : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            Token t;

            try
            {
                t = pu.clauseStack.Peek();
                if (t.Type == "TOKEN_SELECT" || t.Type == "TOKEN_UPDATE" || t.Type == "TOKEN_DELETE" || t.Type == "TOKEN_INSERT")
                {
                    pu.clauseStack.Clear();
                    pu.indentDepth = 0;
                }
            }
            catch (Exception)
            {

            }
            bool shouldIncreaseIndent = this.shouldIncreaseIndent(pu);
            pu.clauseStack.Push(pu.token.Value);
            if (shouldIncreaseIndent)
            {
                pu.indentDepth = pu.indentDepth + 1;

            }

            if (this.shouldSingleReturn(pu))
            {
                return this.GetNewLine(pu) + pu.token.Value.Text.ToUpper() + this.GetNewLine(pu);
            }
            
            return this.FormatOwnLine(pu);

        
        }
        protected bool shouldIncreaseIndent(Formatter.ParseUnit pu)
        {
            
            foreach (Token t in pu.clauseStack)
            {
                if (t.Type == "TOKEN_SELECT" || t.Type == "TOKEN_UPDATE" || t.Type == "TOKEN_DELETE" || t.Type == "TOKEN_INSERT")
                {
                    return true;
                }
            }
            return false;
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
    }
}
