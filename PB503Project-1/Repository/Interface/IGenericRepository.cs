using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        void Create(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
        int Commit();

    }
}
