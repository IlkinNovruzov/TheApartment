using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheApartment.Models.DataModels
{
    public class ApartmentImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
