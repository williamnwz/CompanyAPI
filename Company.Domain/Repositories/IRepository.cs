using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Domain.Repositories
{
    public interface IRepository<T> where T: Entity
    {
        Task Save(T entity);
        Task Delete(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> Find(Func<T, bool> func);
        Task<List<T>> All();


    }
}
