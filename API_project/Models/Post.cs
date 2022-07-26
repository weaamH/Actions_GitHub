using System.ComponentModel.DataAnnotations.Schema;

namespace API_project.Models
{
    public class Post: BaseModel
    {
        public string Title { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User? user { get; set; }
    }
}
