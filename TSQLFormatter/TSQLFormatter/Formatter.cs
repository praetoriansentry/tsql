using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter
{
    class Formatter
    {
        public string Format(String inputSql)
        {
            var pr = Parser.Parse(inputSql.Trim());
            string outSql = "";

            LinkedList<Token> tokenList = new LinkedList<Token>();

            // build a full list
            foreach (Token t in pr.Tokens)
            {
                tokenList.AddLast(t);
            }

            ParseUnit pu = new ParseUnit();
            pu.indentDepth = -1;
            pu.clauseStack = new Stack<Token>();
            pu.sqlBits = new LinkedList<string>();
            pu.token = tokenList.First;

            while(pu.token != null) {
                Interpreter interp = InterpreterFactory.Get(pu.token.Value);
                pu.sqlBits.AddLast(interp.Interpret(ref pu));
                pu.token = pu.token.Next;
            }

            foreach (String sqlString in pu.sqlBits) {
                outSql += sqlString;
            }

            return outSql.Trim();
        }

        public struct ParseUnit
        {
            public LinkedListNode<Token> token;
            public Stack<Token> clauseStack;
            public LinkedList<string> sqlBits;
            public int indentDepth;
        }
    }
}
