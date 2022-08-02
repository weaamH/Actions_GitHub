using Amazon.IdentityManagement.Model;
using API_project.ActionFilters;
using API_project.ClassesViewModels;
using API_project.Models;
using API_project.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;

        public PostController(IPostRepo postRepository, IMapper mapper)
        {
            _postRepo = postRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<List<PostViewModel>>> GetAll() 
        {
            return await _postRepo.getAll<PostViewModel>();    
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostViewModel>> Get(int id) 
        {
            return await _postRepo.Get<PostViewModel>(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _postRepo.Delete(id);
        }
        [HttpPost]
        public async Task Create(PostViewModel postvm)
        {
            var post = _mapper.Map<Post>(postvm);
            await _postRepo.Add(post);
        }
        [HttpPut]
        public async Task Update([FromBody] PostViewModel postvm)
        {
            await _postRepo.Update(_mapper.Map<Post>(postvm));

        }
    }
}
