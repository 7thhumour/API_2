using System.ComponentModel.DataAnnotations;

namespace APIII.Models
{
    public class TableTwo1to1Ex
    {
        [Key]
        public int TableTwoId { get; set; }
        public string TableTwoName { get; set; } = string.Empty;
        public string TableTwoDescription { get; set; } = string.Empty;

        public TableOne1to1Ex TableOne1to1Ex { get; set; }
    }
}
