﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.DataRepository
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public bool IsDeleted { get; set; }
    }
}
