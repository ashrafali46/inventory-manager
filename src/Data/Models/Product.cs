using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
    }
}