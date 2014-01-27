using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter.Interpreters
{
    class Paren : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            if (pu.token.Value.Type == "(")
            {
                pu.clauseStack.Push(pu.token.Value);
            }
            else
            {
                Token t = pu.clauseStack.Peek();
                if (t.Type == "(")
                {
                    pu.clauseStack.Pop();
                }
                else if (t.Type == "TOKEN_SELECT" && pu.clauseStack.Count > 1)
                {
                    pu.clauseStack.Pop(); // Take a select off the stack
                    if (pu.clauseStack.Peek().Type == "(")
                    {
                        pu.clauseStack.Pop(); // Remove the wrapping parentheis
                        pu.indentDepth = pu.indentDepth - 1;
                        return this.GetNewLine(pu) + pu.token.Value.Text;
                    }
                }
            }

            return " " + pu.token.Value.Text + " ";
        }
    }
}
