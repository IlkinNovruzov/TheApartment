using System.Drawing;

namespace TheApartment.Models.DataModels
{
    public class ApartmentFeature
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
