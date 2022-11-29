using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using WebApplication2.Models.DTO;

namespace WebApplication2.Models
{
    public class ApplicationUser: IdentityUser
    {
        //private UserManager<ApplicationUser> userManager;

        //public ApplicationUser(UserManager<ApplicationUser> manager)
        //{
        //    userManager = manager;
        //}
    }
}
