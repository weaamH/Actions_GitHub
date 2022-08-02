using API_project.ClassesViewModels;
using API_project.Models;
using API_project.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_project.Repositories
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        public UserRepo(UserContext context, IMapper mapper) : base(context, mapper) { }

        /*public new List<Vtm>? getAll<Vtm>()
        {
            return context.UserDB.Include(c => c.posts).ToList();
            return context.UserDB.ProjectTo<UserViewModel>(mapper.ConfigurationProvider).ToList();
        }*/
    }
}