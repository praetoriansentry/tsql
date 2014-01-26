using Microsoft.SqlServer.SqlParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLFormatter.Interpreters
{
    class Where : Interpreter
    {
        public override string Interpret(Formatter.ParseUnit pu)
        {
            return this.FormatOwnLine(pu);
        }
    }
}
