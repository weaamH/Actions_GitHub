using API_project.Models;

namespace API_project.ClassesViewModels
{
    public class UserViewModel: BaseModel
    {
        public string firstName
        {
            get;
            set;
        }
        public string lastName
        {
            get;
            set;
        }
        public ICollection<PostViewModel>? posts
        {
            get;
            set;
        }
    }
}
