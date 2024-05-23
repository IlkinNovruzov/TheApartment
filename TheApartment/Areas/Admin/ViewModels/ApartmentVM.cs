using TheApartment.Models.DataModels;

namespace TheApartment.Areas.Admin.ViewModels
{
    public class ApartmentVM
    {
        public Apartment Apartment { get; set; }
        public List<int> FeatureIds { get; set; }
    }
}
