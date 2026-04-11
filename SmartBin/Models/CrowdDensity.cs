using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBin.Models
{
    public class CrowdDensity
    {
        [Key]
        public int CrowdId { get; set; }
        public string DensityLevel { get; set; } // e.g., Low, Medium, High
        public string ImageUrl { get; set; }
        public int PeopleCount { get; set; }
        public DateTime Timestamp { get; set; }
        [ForeignKey("Bin")]
        public int BinId { get; set; }
        public virtual Bin Bin { get; set; }
    }
}
