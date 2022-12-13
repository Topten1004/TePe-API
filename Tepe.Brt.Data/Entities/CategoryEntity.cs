using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tepe.Brt.Data
{
    [Table("Categories")]
    public class CategoryEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? catImage { get; set; }

        public virtual ICollection<MarketEntity> Markets { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}