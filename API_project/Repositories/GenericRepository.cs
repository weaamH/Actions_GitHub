using API_project.Models;

namespace API_project.Repositories
{
    public interface IGenericRepository<T> where T : class, IBaseModel
    {
        public List<T> getAll();
        public T Get(int id);
        public void Delete(int id);
        public T Add(T entity);
        public T Update(T entity);
    }
    public class GenericRepository<T> :  IGenericRepository<T> where T : class, IBaseModel
    {
        private UserContext _context;
        public GenericRepository(UserContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var obj = _context.Set<T>().FirstOrDefault(c => c.Id == id);
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> getAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return entity;
        }
    }
}
