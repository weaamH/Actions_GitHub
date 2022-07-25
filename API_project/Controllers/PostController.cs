using API_project.Models;
using API_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;

        public PostController(IPostRepo postRepository)
        {
            _postRepo = postRepository;
        }
        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            return _postRepo.getAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            var post = _postRepo.Get(id);
            if (post == null)
                return NotFound();
            return post;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = _postRepo.Get(id);
            if (post == null)
                return NotFound();
            _postRepo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult Create([FromBody] Post post)
        {
            _postRepo.Add(post);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update([FromBody] Post post)
        {
            var _post = _postRepo.Get(post.Id);
            if (_post == null)
                return NotFound();
            _postRepo.Update(post);
            return Ok();
        }
    }
}
