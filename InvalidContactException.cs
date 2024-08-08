using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDZ9
{
    public class InvalidContactException : Exception
    {
            public InvalidContactException (string str) : base(str) { }
    }
}
