﻿using Microsoft.AspNetCore.Mvc;
using API_project.Models;
using API_project.Repositories;
using API_project.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API_project.ClassesViewModels;
using System.Security.Claims;

namespace API_project.Controllers
{
    [Authorize]
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
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
            return await _userRepo.getAll<UserViewModel>();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            return await _userRepo.Get<UserViewModel>(id);
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
            var userId = User.Claims?.SingleOrDefault(p => p.Type == "UserId")?.Value;
            await _userRepo.Add(user, Convert.ToInt32(userId));
        }
        [HttpPut]
        public async Task Update(UserViewModel uservm)
        {
            var userId = User.Claims?.SingleOrDefault(p => p.Type == "UserId")?.Value;
            await _userRepo.Update(_mapper.Map<User>(uservm), Convert.ToInt32(userId));
        }
    }
}