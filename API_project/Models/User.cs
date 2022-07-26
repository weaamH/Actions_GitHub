using System.ComponentModel.DataAnnotations;

namespace API_project.Models
{
    public class User: BaseModel
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
