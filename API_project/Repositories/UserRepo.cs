using API_project.Models;
using API_project.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_project.Repositories
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        public UserRepo(UserContext context) : base(context) { }

        /*public new User? Get(int id)
        {
            return _context.UserDB.Include(c => c.posts).ToList();
        }*/
    }
}