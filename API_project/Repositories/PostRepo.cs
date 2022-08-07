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

        public List<Post> getPage(int pageNumber, int pageSize, String str)
        {
            return context.Posts.Where(p => p.Title.Contains(str))
                .Skip(pageNumber*pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
