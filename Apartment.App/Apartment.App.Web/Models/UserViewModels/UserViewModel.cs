using System.Collections.Generic;
using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.UserViewModels
{
    public class UserViewModel
    {

        public List<UserDto> Users { get; set; } = new List<UserDto>();

    }
}
