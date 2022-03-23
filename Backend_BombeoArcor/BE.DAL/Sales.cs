using BE.DAL.DO.Interfaces;
using BE.DAL.EF;
using BE.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL
{
    public class Sales : ICRUD<data.Sales>
    {
        private Repository<data.Sales> repo;

        public Sales(NDbContext dbContext)
        {
            repo = new Repository<data.Sales>(dbContext);
        }
        public void Delete(data.Sales t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Sales> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Sales>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Sales GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Sales> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Sales t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Sales t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
