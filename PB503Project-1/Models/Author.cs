﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public List< Book >Books { get; set; }
    }
}
