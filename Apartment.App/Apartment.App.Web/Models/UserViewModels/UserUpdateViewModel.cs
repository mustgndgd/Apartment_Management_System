using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.UserViewModels
{
    public class UserUpdateViewModel
    {
        public UserDto user { get; set; } = new UserDto();
    }
}
