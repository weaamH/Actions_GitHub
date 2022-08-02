using Microsoft.AspNetCore.Mvc;
using API_project.Models;
using API_project.Repositories;
using API_project.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API_project.ClassesViewModels;

namespace API_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo userRepository, IMapper mapper) 
        {
            _userRepo = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
            var users = await _userRepo.getAll();
            return _mapper.Map<List<UserViewModel>>(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            var user = await _userRepo.Get(id);
            if(user == null)
                return NotFound();
            return _mapper.Map<User, UserViewModel>(user);

        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userRepo.Delete(id);
        }

        [HttpPost]
        public async Task Create(UserViewModel uservm)
        {
            var user = _mapper.Map<User>(uservm);
            await _userRepo.Add(user);
        }
        [HttpPut]
        public async Task Update(UserViewModel uservm)
        {
            await _userRepo.Update(_mapper.Map<User>(uservm));
        }
    }
}