using System.ComponentModel.DataAnnotations;

namespace APIII.Models
{
    public class TableOne1to1Ex
    {
        [Key]
        public int TableOneId { get; set; }
        public string TableOneName { get; set; } = string.Empty;
        public string TableOneDescription { get; set; } = string.Empty;
    }
}

