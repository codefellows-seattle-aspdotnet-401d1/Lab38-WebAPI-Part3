using System.ComponentModel.DataAnnotations;

namespace Lab38George.Models
{
    public class Parts
    {
        // I set the key here preparing for the other table
        [Key]
        public int PartID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Quantity { get; set; }
    }
}
