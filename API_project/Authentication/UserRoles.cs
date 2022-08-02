using Microsoft.AspNetCore.Identity;

namespace API_project.Authentication
{
    public class UserRoles: IdentityRole<int>
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
