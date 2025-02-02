using PB503Project_1.DataBase;
using PB503Project_1.Models;
using PB503Project_1.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Implementations
{
    public class GenericRepostory<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();
        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public void Create(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            entity.UpdatedDate = entity.CreatedDate;

            _appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
        }

        public T GetById(int id)
        {
            return _appDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _appDbContext.Set<T>().Where(x=>!x.IsDeleted ).ToList();
        }


    }
}
