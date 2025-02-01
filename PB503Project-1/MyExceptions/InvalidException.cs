using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.MyExceptions
{
    public class InvalidException : Exception
    {
        public InvalidException()
        {
        }

        public InvalidException(string? message) : base(message)
        {
        }
    }
}
