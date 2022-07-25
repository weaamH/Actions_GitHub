using API_project.Models;
using API_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Repositories
{
    public class PostRepo: IPostRepo
    {
        private UserContext _context;
        public PostRepo(UserContext context)
        {
            _context = context;
        }
        public List<Post> getAll()
        {
            List<Post> postsList;
            try
            {
                postsList = _context.Posts.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return postsList;
        }
        public Post Get(int id)
        {
            Post? post;
            try
            {
                post = _context.Posts.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return post;
        }
        public void Delete(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Post _post = Get(id);
                if (_post != null)
                {
                    _context.Posts.Remove(_post);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
        }
        public void Add(Post newPost)
        {
            Post _post = Get(newPost.Id);
            if (_post == null)
            {
                _context.Posts.Add(newPost);
                ResponseModel model = new ResponseModel();
                model.Messsage = "Employee Inserted Successfully";
                _context.SaveChanges();
            }
        }
        public void Update(Post newPost)
        {
            Post? _post = Get(newPost.Id);
            if (_post != null)
            {
                _post.Id = newPost.Id;
                _post.Title = newPost.Title;
                _post.user = newPost.user;

                _context.Posts.Update(_post);
                _context.SaveChanges();
            }
        }
    }
}
