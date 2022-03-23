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
    public class Instalador : ICRUD<data.Instalador>
    {
        private Repository<data.Instalador> repo;
        public Instalador(NDbContext dbContext)
        {
            repo = new Repository<data.Instalador>(dbContext);
        }
        public void Delete(data.Instalador t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Instalador> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Instalador>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Instalador GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Instalador> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Instalador t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Instalador t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}