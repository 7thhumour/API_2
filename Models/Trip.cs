using System.ComponentModel.DataAnnotations;

namespace APIII.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [MaxLength(75)]
        public string TripName { get; set;} = string.Empty;
        
        [MaxLength(50)]
        public string? Startlocation { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        [Range(0, 500)]
        public int Distance { get; set; }

        [Range(1,100)]
        public int MaxGroupSize { get; set; }

        [MaxLength(50)]
        public string? Type { get; set; }

        [MaxLength(50)]
        public string? Season { get; set; }


        // a many-to-many relationship
        public List<Guide> Guides { get; set; } = new List<Guide>();


    }
}
