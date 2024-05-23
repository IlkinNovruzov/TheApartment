namespace TheApartment.Models.DataModels
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<ApartmentFeature> ApartmentFeatures { get; set; }
    }
}
