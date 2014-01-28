using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter.Interpreters
{
    class Comma : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            Token t = null;
            Token t2 = null;
            try
            {
                t = pu.clauseStack.Peek();
                if (t.Type == "(")
                {
                    pu.clauseStack.Pop();
                    try
                    {
                        t2 = pu.clauseStack.Peek();
                    }
                    finally
                    {
                        pu.clauseStack.Push(t);
                    } 
                }
            }
            catch (Exception)
            {
                return ", ";
            }

            if (t2 != null && t2.Type == "TOKEN_CREATE")
            {
                return "," + this.GetNewLine(pu);
            }
            if (t.Type == "TOKEN_SELECT" || t.Type == "TOKEN_DECLARE")
            {
                return "," + this.GetNewLine(pu);
            }
            return ", ";
        }
    }
}
