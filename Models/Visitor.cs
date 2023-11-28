using System.ComponentModel.DataAnnotations;

namespace InterstellarApp.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation prop för many-to-many relationship
        public ICollection<PlanetVisitors> PlanetVisitors { get; set; } = new List<PlanetVisitors>();
    }
}
