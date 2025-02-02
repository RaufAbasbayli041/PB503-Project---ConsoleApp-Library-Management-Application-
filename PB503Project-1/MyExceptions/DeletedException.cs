using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.MyExceptions
{
    public class DeletedException : Exception
    {
        public DeletedException()
        {
        }

        public DeletedException(string? message) : base(message)
        {
        }
    }
}
