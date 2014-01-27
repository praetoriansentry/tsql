using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter
{
    class InterpreterFactory
    {
        protected static bool isOperator(Token t)
        {
            string[] opTypes = Interpreters.Operator.operators;
            if (opTypes.Contains(t.Type))
            {
                return true;
            }
            return false;
        }
        public static Interpreter Get(Token t)
        {
            Console.WriteLine(t.Type);
            switch (t.Type)
            {
                case "LEX_END_OF_LINE_COMMENT":
                    return new Interpreters.Comment();
                case "LEX_MULTILINE_COMMENT":
                    return new Interpreters.Comment();
                case "TOKEN_END":
                    return new Interpreters.End();
                case "TOKEN_BEGIN":
                    return new Interpreters.Begin();
                case "TOKEN_WHILE":
                    return new Interpreters.While();
                case "TOKEN_FETCH":
                    return new Interpreters.Fetch();
                case "TOKEN_NEXT":
                    return new Interpreters.Next();
                case "TOKEN_ON":
                    return new Interpreters.On();
                case "TOKEN_GROUP":
                    return new Interpreters.Group();
                case "TOKEN_ORDER":
                    return new Interpreters.Order();
                case "TOKEN_BY":
                    return new Interpreters.By();
                case "TOKEN_JOIN":
                    return new Interpreters.Join();
                case "TOKEN_RIGHT":
                    return new Interpreters.Right();
                case "TOKEN_LEFT":
                    return new Interpreters.Left();
                case "TOKEN_AND":
                    return new Interpreters.And();
                case "TOKEN_WHERE":
                    return new Interpreters.Where();
                case "TOKEN_FROM":
                    return new Interpreters.From();
                case "(":
                    return new Interpreters.Paren();
                case ")":
                    return new Interpreters.Paren();
                case ",":
                    return new Interpreters.Comma();
                case "TOKEN_SELECT":
                    return new Interpreters.Select();
                case "LEX_WHITE":
                    return new Interpreters.White();
                default:
                    if (InterpreterFactory.isOperator(t))
                    {
                        return new Interpreters.Operator();
                    }
                    return new Interpreters.Default();
            }
        }
    }
}
