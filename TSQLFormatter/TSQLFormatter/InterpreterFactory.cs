﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.SqlParser.Parser;

namespace TSQLFormatter
{
    class InterpreterFactory
    {
        public static Interpreter Get(Token t)
        {
            Console.WriteLine(t.Type);
            switch (t.Type)
            {
                case "LEX_WHITE":
                    return new Interpreters.White();
                default:
                    return new Interpreters.Default();
            }
        }
    }
}
