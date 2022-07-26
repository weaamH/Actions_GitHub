using API_project.Models;
using API_project.ViewModels;

namespace API_project.Repositories
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        public UserRepo(UserContext context) : base(context) { }
    }
}