﻿using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Interface
{
    public interface IBorrowerRepository : IGenericRepository<Borrower>
    {
        List<Borrower> GetAllByInclude();
        Borrower? GetByIdInclude(int id);
    }
}
