using API_project.ActionFilters;
using API_project.Models;
using API_project.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace API_project
{
    public static class Initialization
    {
        public static void Initilize(this IServiceCollection serv)
        {
            serv.AddScoped<IUserRepo, UserRepo>();
            serv.AddScoped<IPostRepo, PostRepo>();
            serv.AddScoped<ValidationFilterAttribute>();
        }
    }
}
