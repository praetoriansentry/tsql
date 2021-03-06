﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter.Interpreters
{
    class End : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {

            Token t = pu.clauseStack.Peek();
            if (t.Type == "TOKEN_BEGIN" || t.Type == "TOKEN_CASE")
            {
                pu.clauseStack.Pop();
                pu.indentDepth -= 1;
            }
            return this.GetNewLine(pu) + pu.token.Value.Text.ToUpper() + this.GetNewLine(pu);
        }
    }
}
