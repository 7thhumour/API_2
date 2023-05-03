using System.ComponentModel.DataAnnotations;

namespace APIII.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        // The .empty property allows a zero length to be stored
        // The question mark means allowance of null entries
        public string? Address { get; set; }
        public string? City { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        [StringLength(5)]
        public string? PostalCode { get; set;}

        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
