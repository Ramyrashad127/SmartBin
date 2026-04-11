using System.ComponentModel.DataAnnotations;

namespace SmartBin.Models
{
    public class SurroundingWaste
    {
        [Key]
        public int Id { get; set; }
        public string WasteLevel { get; set; }
        public string ImageUrl { get; set; }
        public int DetectedObjectsCount { get; set; }
        public float AiConfidencePercentage { get; set; }
        public DateTime Timestamp { get; set; }

        public int BinId { get; set; }
        public virtual Bin Bin { get; set; }
    }
}
