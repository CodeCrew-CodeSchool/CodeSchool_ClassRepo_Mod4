using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using WebApplication2.Models.DTO;

namespace WebApplication2.Models.Interfaces
{
    public interface IUser
    {
        Task<UserDto> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        Task<UserDto> Authenticate(string username, string password);
    }
}
