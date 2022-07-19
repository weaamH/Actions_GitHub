using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API_project.Models;
using API_project.Repositories;

namespace API_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return UserRepo.getAll();
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null)
                return NotFound();
            return user;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null)
                return NotFound();
            UserRepo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            UserRepo.Add(user);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(User user, int id)
        {
            var oldUser = UserRepo.Get(user.Id);
            if (oldUser == null)
                return NotFound();
            UserRepo.Update(user, id);
            return Ok();
        }
    }
}
