using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_project.Models
{
    public class Post: IdentityUser<int>, IBaseModel
    {
        public string Title { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User? user { get; set; }
        public DateTime created_at { get; set; }
        public int created_by { get; set; }
        public DateTime updated_at { get; set; }
        public int modified_by { get; set; }
    }
}
