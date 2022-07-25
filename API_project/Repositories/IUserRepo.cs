using API_project.Models;

namespace API_project.Repositories
{
    public interface IUserRepo
    {
        public List<User> getAll();
        public User Get(int id);
        public void Delete(int id);
        public void Add(User newUser);
        public void Update(User newUser);
    }
}
