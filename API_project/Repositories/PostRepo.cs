using API_project.ClassesViewModels;
using API_project.Models;
using API_project.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_project.Repositories
{
    public class PostRepo: GenericRepository<Post>, IPostRepo
    {
        public PostRepo(UserContext context, IMapper mapper) : base(context, mapper) { }

        /*public new List<Tvm>? getAll<Tvm>()
        {
            return context.Posts.Include(c => c.user_id).ToList();
            return context.Posts.ProjectTo<PostViewModel>(mapper.ConfigurationProvider).ToList();

        }*/

    }
    
}
