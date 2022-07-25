using System.ComponentModel.DataAnnotations;

namespace API_project.Models
{
    public class User
    {
        [Key]
        public int Id { 
            get; 
            set; 
        }
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
