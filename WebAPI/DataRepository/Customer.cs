using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataRepository
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(5)]
        public bool IsDeleted { get; set; }
    }
}