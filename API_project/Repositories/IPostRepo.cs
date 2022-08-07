using API_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Repositories
{
    public interface IPostRepo: IGenericRepository<Post>
    {
        public List<Post> getPage(int pageNumber, int pageSize, String str);
    }
}
