using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Apartment.App.Domain.Entities.IdentityEntities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TrIdentityNumber { get; set; }

        public bool HasCar { get; set; }
        public string CarPlateNumber { get; set; }

    }
}
