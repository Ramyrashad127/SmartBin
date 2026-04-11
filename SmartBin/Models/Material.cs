using System.ComponentModel.DataAnnotations;

namespace SmartBin.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        [Required]
        public string Name { get; set; } // e.g., "Plastic", "Paper", "Metal"

        public List<BinSection> BinSections { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
