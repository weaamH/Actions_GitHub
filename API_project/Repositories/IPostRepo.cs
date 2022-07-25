using API_project.Models;

namespace API_project.Repositories
{
    public interface IPostRepo
    {
        public List<Post> getAll();
        public Post Get(int id);
        public void Delete(int id);
        public void Add(Post newPost);
        public void Update(Post newPost);
    }
}
