using DAL.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Interfaces
{
    class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork uow;

        public GenericService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Task<T> Create(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsynById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsyn(T item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
