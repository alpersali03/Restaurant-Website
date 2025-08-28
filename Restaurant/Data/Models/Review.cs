using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        public int Rating { get; set; } 
        [StringLength(200)]
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public int ProductId { get; set; }             
        public List<Product> Products { get; set; }    
    }

}
