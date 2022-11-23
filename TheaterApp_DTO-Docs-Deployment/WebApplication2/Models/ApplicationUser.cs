using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using WebApplication2.Models.DTO;

namespace WebApplication2.Models
{
    public class ApplicationUser: IdentityUser
    {
        private static UserManager<ApplicationUser> userManager;

        public ApplicationUser(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }

        public ApplicationUser()
        {
        }

        //public ApplicationUser(string username, string email, string phonenumber)
        //{

        //}
        public static async Task<UserDto> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            // throw new NotImplementedException();
            var user = new ApplicationUser()
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            // What about our errors?
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;

        }

        public static async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
            }

            return null;
        }
    }
}
