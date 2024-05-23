using TheApartment.Models.DataModels;

namespace TheApartment.Models.ViewModels
{
    public class DetailsVM
    {
        public Apartment Apartment { get; set; }
        public SendEmailVM SendEmailVM { get; set; }
        public ApartmentInfo ApartmentInfo { get; set; }
    }
}
