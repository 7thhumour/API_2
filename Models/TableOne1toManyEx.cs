using System.ComponentModel.DataAnnotations;

namespace APIII.Models
{
    public class TableOne1toManyEx
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<TableTwo1toManyEx> TableTwo1toManyEx { get; set; } = new List<TableTwo1toManyEx>();
    }
}
