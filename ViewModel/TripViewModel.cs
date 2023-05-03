using System.ComponentModel.DataAnnotations;

namespace APIII.ViewModel
{
    public class TripViewModel
    {
        public string TripName { get; set; }

        public string? Startlocation { get; set; }

        public string? State { get; set; }
        public int Distance { get; set; }

        public int MaxGroupSize { get; set; }

        public string? Type { get; set; }

        public string? Season { get; set; }
    }
}
