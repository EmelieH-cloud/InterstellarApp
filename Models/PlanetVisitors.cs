namespace InterstellarApp.Models
{
    public class PlanetVisitors
    {
        // utgör vårt junction table. 
        public int PlanetId { get; set; }
        public Planet Planet { get; set; } = null!;
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; } = null!;
    }
}
