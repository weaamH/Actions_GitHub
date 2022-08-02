using API_project.ClassesViewModels;
using API_project.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API_project.Repositories
{
    public interface IGenericRepository<T> where T : class, IBaseModel
    {
        public Task<List<Tvm>> getAll<Tvm>();
        public Task<Tvm> Get<Tvm>(int id) where Tvm : class, IBaseModel;
        public Task Delete(int id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
    }
    public class GenericRepository<T> :  IGenericRepository<T> where T : class, IBaseModel
    {
        public UserContext context;
        public IMapper mapper;
        public GenericRepository(UserContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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

        public async Task<Tvm> Get<Tvm>(int id) where Tvm :class , IBaseModel
        {
            return context.Set<T>()
                .ProjectTo<Tvm>(mapper.ConfigurationProvider)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Tvm>> getAll<Tvm>()
        {
            return context.Set<T>().ProjectTo<Tvm>(mapper.ConfigurationProvider).ToList();
        }

        public async Task<T> Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
