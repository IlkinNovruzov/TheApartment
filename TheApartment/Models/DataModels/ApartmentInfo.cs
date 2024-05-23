using System.ComponentModel.DataAnnotations;

namespace TheApartment.Models.DataModels
{
    public class ApartmentInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExtraInfo { get; set; }

        [Required]
        public string Rules { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string City { get; set; }
    }
}
