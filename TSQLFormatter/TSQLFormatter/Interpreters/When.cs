﻿using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class When : Interpreter
    {
        public override string Interpret(ref Formatter.ParseUnit pu)
        {
            return this.GetNewLine(pu) + pu.token.Value.Text.ToUpper();
        }
    }
}
