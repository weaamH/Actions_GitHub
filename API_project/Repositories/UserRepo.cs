using API_project.Models;

namespace API_project.Repositories
{
    public class UserRepo
    {
        static List<User> users { get; set; }

        static UserRepo()
        {
            users = new List<User>()
            {
                new User(){ Id=1, firstName="Weaam", lastName = "Hjijah"},
                new User(){ Id=2, firstName="Aya", lastName = "Taleb"},
                new User(){ Id=3, firstName="Israa", lastName = "Haseeba"},
                new User(){ Id=4, firstName="Siham", lastName = "Abu Rmeilah"},
                new User(){Id=5, firstName="Maram", lastName = "Hjijah"}
            };
        }

        public static List<User> getAll()
        {
            return users;
        }

        public static User Get(int id)
        {
            return users.FirstOrDefault(User => User.Id == id);
        }
        public static void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
                users.Remove(user);
        }
        public static void Add(User newUser)
        {
            users.Add(newUser);
        }
        public static void Update(User user, int id)
        {
            var oldUserIndex = users.FindIndex(User => User.Id == id);
            if (oldUserIndex == -1)
                return;
            users[oldUserIndex] = user;
        }
    }
}
