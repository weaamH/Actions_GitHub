using System.ComponentModel.DataAnnotations.Schema;

namespace API_project.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("User")]
        public int user_id;
        public User? user { get; set; }
    }
}
