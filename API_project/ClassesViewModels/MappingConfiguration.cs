using API_project.Models;
using AutoMapper;

namespace API_project.ClassesViewModels
{
    public class MappingConfiguration: Profile
    {
        public MappingConfiguration() 
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
        }
        
    }
}
