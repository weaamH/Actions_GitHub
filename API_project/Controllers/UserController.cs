using Microsoft.AspNetCore.Mvc;
using API_project.Models;
using API_project.Repositories;

namespace API_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepository) 
        {
            _userRepo = userRepository;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userRepo.getAll();
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
                return NotFound();
            return user;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
                return NotFound();
            _userRepo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult Create([FromBody] User user)
        {
            _userRepo.Add(user);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update([FromBody] User user)
        {
            var _user = _userRepo.Get(user.Id);
            if (_user == null)
                return NotFound();
            _userRepo.Update(_user);
            return Ok();
        }
    }
}