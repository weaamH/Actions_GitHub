﻿using API_project.Models;
using API_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Repositories
{
    public class PostRepo: GenericRepository<Post>, IPostRepo
    {
        public PostRepo(UserContext context) : base(context) { }
    }
}
