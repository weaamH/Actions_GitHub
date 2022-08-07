using API_project.ClassesViewModels;
using API_project.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API_project.Repositories
{
    public interface IGenericRepository<T> where T : class, IBaseModel
    {
        public Task<List<Tvm>> getAll<Tvm>();
        public Task<Tvm> Get<Tvm>(int id) where Tvm : class, IBaseModel;
        public Task Delete(int id);
        public Task<T> Add(T entity, int id);
        public Task<T> Update(T entity, int id);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseModel
    {
        public UserContext context;
        public IMapper mapper;
        public GenericRepository(UserContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<T> Add(T entity, int id)
        {
            PropertyInfo time = entity.GetType().GetProperty("created_at");
            if (time != null)
            {
                time.SetValue(entity, DateTime.Now);
                PropertyInfo person = entity.GetType().GetProperty("created_by");
                person.SetValue(entity, id);
            }
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

        public async Task<T> Update(T entity, int id)
        {
            PropertyInfo time = entity.GetType().GetProperty("updated_at");
            if (time != null)
            {
                time.SetValue(entity, DateTime.Now);
                PropertyInfo person = entity.GetType().GetProperty("modified_by");
                person.SetValue(entity, id);
            }
            context.Set<T>().Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
