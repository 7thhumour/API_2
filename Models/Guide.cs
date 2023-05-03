using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIII.Models
{
    public class Guide
    {
       
        [StringLength(4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string GuideNum { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        [StringLength(5)]
        [RegularExpression(@"^\d+$")]
        public string? PostalCode { get; set; }
        
        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime HireDate { get; set; }

        // a one-to-many relationship
        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
