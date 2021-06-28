using Company.Domain.Entities;
using Company.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DatabaseContext context;
        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<List<T>> All()
        {
            return this.context.Set<T>().ToList();
        }

        public async Task Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> Find(Func<T, bool> func)
        {
            return this.context.Set<T>().Where(func).ToList();
        }

        public async Task<T> GetById(Guid id)
        {
            return this.context.Set<T>().FirstOrDefault(entity => entity.Id == id);
        }

        public async Task Save(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                await context.Set<T>().AddAsync(entity);
            }
            else
            {
                context.Entry(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
                
        }
    }
}
