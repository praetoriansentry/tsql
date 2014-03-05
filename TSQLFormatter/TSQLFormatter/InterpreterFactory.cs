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
            switch (t.Type)
            {
                case "TOKEN_HAVING":
                    return new Interpreters.Having();
                case "TOKEN_IN":
                    return new Interpreters.In();
                case "TOKEN_PIVOT":
                    return new Interpreters.Pivot();
                case "TOKEN_ASC":
                    return new Interpreters.Asc();
                case "TOKEN_DESC":
                    return new Interpreters.Desc();
                case ";":
                    return new Interpreters.Semicolon();
                case "TOKEN_EXISTS":
                    return new Interpreters.Exists();
                case "TOKEN_DISTINCT":
                    return new Interpreters.Distinct();
                case "TOKEN_REFERENCES":
                    return new Interpreters.References();
                case "TOKEN_CONSTRAINT":
                    return new Interpreters.Constraint();
                case "TOKEN_AS":
                    return new Interpreters.As();
                case "TOKEN_CLUSTERED":
                    return new Interpreters.Clustered();
                case "TOKEN_s_IO_ONOFFOPTION":
                    return new Interpreters.SIOOnOffOption();
                case "TOKEN_OFF":
                    return new Interpreters.Off();
                case "TOKEN_UNIQUE":
                    return new Interpreters.Unique();
                case "TOKEN_ROWGUIDCOL":
                    return new Interpreters.Rowguidcol();
                case "TOKEN_KEY":
                    return new Interpreters.Key();
                case "TOKEN_PRIMARY":
                    return new Interpreters.Primary();
                case "TOKEN_DEFAULT":
                    return new Interpreters.DefaultToken();
                case "TOKEN_IDENTITY":
                    return new Interpreters.Identity();
                case "TOKEN_CREATE":
                    return new Interpreters.Create();
                case "TOKEN_TABLE":
                    return new Interpreters.Table();
                case "TOKEN_DROP":
                    return new Interpreters.Drop();
                case "TOKEN_NULL":
                    return new Interpreters.Null();
                case "TOKEN_IS":
                    return new Interpreters.Is();
                case "TOKEN_NOT":
                    return new Interpreters.Not();
                case "TOKEN_EXECUTE":
                    return new Interpreters.Execute();
                case "TOKEN_LIKE":
                    return new Interpreters.Like();
                case "LEX_BATCH_SEPERATOR":
                    return new Interpreters.Go();
                case "TOKEN_USEDB":
                    return new Interpreters.Use();
                case "TOKEN_FULL":
                    return new Interpreters.Full();
                case "TOKEN_CROSS":
                    return new Interpreters.Cross();
                case "TOKEN_OUTER":
                    return new Interpreters.Outer();
                case "TOKEN_VARIABLE":
                    return new Interpreters.Variable();
                case "TOKEN_WITH":
                    return new Interpreters.With();
                case "TOKEN_ID":
                    return new Interpreters.Id();
                case "TOKEN_STRING":
                    return new Interpreters.String();
                case "TOKEN_NUMERIC":
                    return new Interpreters.Numeric();
                case "TOKEN_INTEGER":
                    return new Interpreters.Integer();
                case "TOKEN_OR":
                    return new Interpreters.Or();
                case "TOKEN_WHEN":
                    return new Interpreters.When();
                case "TOKEN_THEN":
                    return new Interpreters.Then();
                case "TOKEN_ELSE":
                    return new Interpreters.Else();
                case "TOKEN_CASE":
                    return new Interpreters.Case();
                case "TOKEN_SET":
                    return new Interpreters.Set();
                case "TOKEN_DECLARE":
                    return new Interpreters.Declare();
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
