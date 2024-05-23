using System.ComponentModel.DataAnnotations;

namespace TheApartment.Models.DataModels
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxPeople { get; set; }
        [Required]
        public int BathRooms { get; set; }
        [Required]
        public int BedRooms { get; set; }
        [Required]
        public double PricePerNight { get; set; }
        [Required]
        public TimeSpan CheckInTime { get; set; }
        [Required]
        public TimeSpan CheckOutTime { get; set; }
        public bool IsActive { get; set; }

        public List<ApartmentFeature> ApartmentFeatures { get; set; }
        public List<ApartmentImage> ApartmentImages { get; set; }
    }
}
