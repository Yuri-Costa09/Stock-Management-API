using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; } // chave estrangeira para a tabela Category
        public string Image { get; set; }
    }
}
