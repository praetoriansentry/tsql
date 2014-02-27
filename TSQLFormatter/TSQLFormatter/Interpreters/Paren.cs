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
                Token t;
                bool isCreate = false;
                try
                {
                    t = pu.clauseStack.Peek();
                    if (t.Type == "TOKEN_CREATE")
                    {
                        pu.indentDepth = 1;
                        isCreate = true;
                    }
                }
                catch (Exception) { }
                pu.clauseStack.Push(pu.token.Value);
                if (isCreate)
                {
                    return pu.token.Value.Text + this.GetNewLine(pu);
                }


            }
            else
            {
                Token t = pu.clauseStack.Peek();

                if (t.Type == "TOKEN_SELECT" && pu.clauseStack.Count > 1)
                {
                    pu.clauseStack.Pop(); // Take a select off the stack
                    if (pu.clauseStack.Peek().Type == "(")
                    {
                        pu.clauseStack.Pop(); // Remove the wrapping parentheis
                        pu.indentDepth = pu.indentDepth - 1;
                        return this.GetNewLine(pu) + pu.token.Value.Text + " ";
                    }
                }
                else if (t.Type == "(" && pu.clauseStack.Count > 1)
                {
                    pu.clauseStack.Pop();
                    if (pu.clauseStack.Peek().Type == "TOKEN_CREATE")
                    {
                        pu.clauseStack.Pop();
                        pu.indentDepth = pu.indentDepth - 1;
                        return this.GetNewLine(pu) + pu.token.Value.Text + " ";
                    }
                }
                else
                {
                    pu.clauseStack.Pop();

                }
            }

            if (pu.token.Value.Type == ")")
            {
                return pu.token.Value.Text + " ";
            }
            return pu.token.Value.Text;


        }
    }
}
