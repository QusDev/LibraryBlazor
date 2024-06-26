﻿using System.ComponentModel.DataAnnotations;

namespace LibraryBlazor.Entity.Entities
{
    public class Reader
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
