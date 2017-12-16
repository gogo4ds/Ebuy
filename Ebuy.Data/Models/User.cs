namespace Ebuy.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        //[MinLength(2), MaxLength(50)]
        //public string FirstName { get; set; }

        //[MinLength(2), MaxLength(50)]
        //public string LastName { get; set; }

        //public DateTime? Birthdate { get; set; }

        //public byte[] ProfilePicture { get; set; }
    }
}