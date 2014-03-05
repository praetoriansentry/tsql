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
                if (!this.isUnion(pu) && (t.Type == "TOKEN_SELECT" || t.Type == "TOKEN_UPDATE" || t.Type == "TOKEN_DELETE" || t.Type == "TOKEN_INSERT" || t.Type == "TOKEN_DECLARE"))
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
            if (shouldIncreaseIndent && !this.isUnion(pu))
            {
                pu.indentDepth = pu.indentDepth + 1;

            }

            return this.FormatOwnLine(pu);

        
        }
        protected bool isUnion(Formatter.ParseUnit pu)
        {
            LinkedListNode<Token> currentNode = pu.token;
            for (int i = 0; i < 3; i = i + 1)
            {
                currentNode = currentNode.Previous;
                if (currentNode == null)
                {
                    return false;
                }
                if (currentNode.Value.Type == "TOKEN_UNION") {
                    return true;
                }
            }
            return false;

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
            LinkedListNode<Token> tNode = pu.token.Previous;
            for (int i = 0; i < 2; i = i + 1)
            {
                if (tNode == null)
                {
                    break;
                }
                if (tNode.Value.Type == "(")
                {
                    return true;
                }
                tNode = tNode.Previous;
            }
                return false;
        }

    }
}
