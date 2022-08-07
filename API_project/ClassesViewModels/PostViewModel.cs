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
        /*public DateTime? created_at { 
            get; 
            set; 
        }
        public DateTime created_by 
        { 
            get; 
            set; 
        }
        public DateTime updated_at 
        { 
            get; 
            set; 
        }
        public DateTime modified_by 
        { 
            get; 
            set; 
        }*/
    }
}
