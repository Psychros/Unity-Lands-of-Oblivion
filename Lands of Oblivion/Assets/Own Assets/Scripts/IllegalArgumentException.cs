using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class IllegalArgumentException : Exception
{
    public IllegalArgumentException(String str) : base(str) { }
}
