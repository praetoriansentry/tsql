using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace TSQLFormatter
{
    class Formatter
    {
        public string Format(String inputSql, BackgroundWorker bw)
        {
            bw.ReportProgress(0);

            var pr = Parser.Parse(inputSql.Trim());
            string outSql = "";

            bw.ReportProgress(10);

            LinkedList<Token> tokenList = new LinkedList<Token>();

            // build a full list
            foreach (Token t in pr.Tokens)
            {
                tokenList.AddLast(t);
            }

            bw.ReportProgress(20);

            ParseUnit pu = new ParseUnit();
            pu.indentDepth = 0;
            pu.clauseStack = new Stack<Token>();
            pu.sqlBits = new LinkedList<string>();
            pu.token = tokenList.First;

            int totalTokens = tokenList.Count;
            int currentTokenCount = 0;

            while(pu.token != null) {
                Interpreter interp = InterpreterFactory.Get(pu.token.Value);
                pu.sqlBits.AddLast(interp.Interpret(ref pu));
                pu.token = pu.token.Next;

                currentTokenCount += 1; bw.ReportProgress((currentTokenCount * 80 /totalTokens) + 20);
            }

            foreach (String sqlString in pu.sqlBits) {
                outSql += sqlString;
            }

            outSql = Regex.Replace(outSql, @"^(\s*)$", "", RegexOptions.Multiline);
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
