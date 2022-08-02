using API_project.Models;

namespace API_project.ClassesViewModels
{
    public class PostViewModel: BaseModel
    {
        public string Title 
        { 
            get; 
            set; 
        }
        public int user_id 
        { 
            get; 
            set; 
        }
    }
}
