using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace API_project.Models
{
    public class User: IdentityUser<int>, IBaseModel
    {
        public string firstName { 
            get; 
            set; 
        }
        public string lastName { 
            get; 
            set; 
        }
        public ICollection<Post>? posts
        {
            get;
            set;
        }
    }
}
