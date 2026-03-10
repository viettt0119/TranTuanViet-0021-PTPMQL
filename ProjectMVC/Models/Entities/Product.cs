using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = default!;
    }
}
