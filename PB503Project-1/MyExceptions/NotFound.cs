using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.MyExceptions
{
    public class NotFound : Exception
    {
        public NotFound()
        {
        }

        public NotFound(string? message) : base(message)
        {
        }
    }
}
