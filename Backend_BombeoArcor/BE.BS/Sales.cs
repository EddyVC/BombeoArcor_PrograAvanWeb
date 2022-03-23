using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class Sales : ICRUD<data.Sales>
    {
        private dal.Sales _dal;

        public Sales(NDbContext dbContext)
        {
            _dal = new dal.Sales(dbContext);
        }
        public void Delete(data.Sales t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Sales> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Sales>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Sales GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Sales> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Sales t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Sales t)
        {
            _dal.Update(t);
        }
    }
}
