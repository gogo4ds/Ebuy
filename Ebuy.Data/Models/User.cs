namespace Ebuy.Data.Models
{
    using System;
    using System.Collections.Generic;
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

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}