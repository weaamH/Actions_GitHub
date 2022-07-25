using API_project.Models;
using API_project.ViewModels;

namespace API_project.Repositories
{
    public class UserRepo: IUserRepo
    {

        private UserContext _context;
        public UserRepo(UserContext context)
        {
            _context = context;
        }
        public List<User> getAll()
        {
            List<User> usersList;
            try
            {
                usersList = _context.UserDB.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return usersList;
        }
        public User Get(int id)
        {
            User user;
            try
            {
                user = _context.UserDB.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        void IUserRepo.Delete(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = Get(id);
                if (_temp != null)
                {
                    _context.UserDB.Remove(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
        }
        void IUserRepo.Add(User newUser)
        {
            User _temp = Get(newUser.Id);
            if (_temp == null)
            {
                _context.UserDB.Add(newUser);
                ResponseModel model = new ResponseModel();
                model.Messsage = "Employee Inserted Successfully";
                _context.SaveChanges();
            }
        }
        void IUserRepo.Update(User newUser)
        {
            User _temp = Get(newUser.Id);
            if (_temp != null)
            {
                _temp.Id = newUser.Id;
                _temp.firstName = newUser.firstName;
                _temp.lastName = newUser.lastName;
                _context.UserDB.Update(_temp);
                _context.SaveChanges();
            }
        }
    }
}