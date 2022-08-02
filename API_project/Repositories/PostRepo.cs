using API_project.Models;
using API_project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_project.Repositories
{
    public class PostRepo: GenericRepository<Post>, IPostRepo
    {
        public PostRepo(UserContext context) : base(context) { }

        public new List<Post>? getAll()
        {
            return context.Posts.Include(c => c.user_id).ToList();
        }

    }
    
}
