using Apartment.App.Business.DTO;
using Microsoft.Net.Http.Headers;

namespace Apartment.App.Web.Models.UserViewModels
{
    public class UserAddViewModel
    {
        public UserDto User { get; set; } = new UserDto();
    }
}
