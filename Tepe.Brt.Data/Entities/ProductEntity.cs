using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tepe.Brt.Data
{
    [Table("Products")]
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Size { get; set; }

        public string? Hex { get; set; }

        public Guid CategoryID { get; set; }

        public CategoryEntity? Category { get; set; }
    }
}