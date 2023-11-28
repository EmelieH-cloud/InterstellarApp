using System.ComponentModel.DataAnnotations;

namespace InterstellarApp.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String? Description { get; set; }
        public int Kilometers { get; set; }

        // Navigation prop för many-to-many relationship
        public ICollection<PlanetVisitors> PlanetVisitors { get; set; } = new List<PlanetVisitors>();

        public override string ToString()
        {
            return $"Planet: Id: {Id}, Name: {Name}, Description: {Description}, Kilometers: {Kilometers}";
        }

    }
}
