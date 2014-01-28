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

    }
}
