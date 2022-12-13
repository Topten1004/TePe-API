using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tepe.Brt.Data
{
    [Table("Markets")]
    public class MarketEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? Country { get; set; }

        public string? LangCode { get; set; }

        public virtual ICollection<CategoryEntity> Categories { get; set; }
    }
}