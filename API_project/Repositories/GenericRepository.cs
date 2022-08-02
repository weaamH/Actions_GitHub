using API_project.Models;
using Microsoft.EntityFrameworkCore;

namespace API_project.Repositories
{
    public interface IGenericRepository<T> where T : class, IBaseModel
    {
        public Task<List<T>> getAll();
        public Task<T> Get(int id);
        public Task Delete(int id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
    }
    public class GenericRepository<T> :  IGenericRepository<T> where T : class, IBaseModel
    {
        public UserContext context;
        public GenericRepository(UserContext context)
        {
            this.context = context;
        }
        public async Task<T> Add(T entity)
        {
           await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var obj = context.Set<T>().FirstOrDefault(c => c.Id == id);
            context.Set<T>().Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public async Task<List<T>> getAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
