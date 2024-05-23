using TheApartment.Models.DataModels;
using static System.Net.Mime.MediaTypeNames;

namespace TheApartment.Areas.Admin.ViewModels
{
    public class ImageVM
    {
        public int ApartmentId { get; set; }
        public List<ApartmentImage> Images { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
