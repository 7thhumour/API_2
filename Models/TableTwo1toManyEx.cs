using System.ComponentModel.DataAnnotations;

namespace APIII.Models
{
    public class TableTwo1toManyEx
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
