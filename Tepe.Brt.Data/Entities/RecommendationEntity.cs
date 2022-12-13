using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tepe.Brt.Data.Entities
{
    public class RecommendationEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Comment { get; set; }

        public string? TeethImage { get; set; }

        public string? Bridge { get; set; }

        public string? Missing { get; set; }

        [NotMapped]
        public int[] BridgeArray { get; set; }

        [NotMapped]
        public int[] MissingArray { get; set; }

        public Guid PatientID { get; set; }

        public PatientEntity? Patient { get; set; }

        public virtual ICollection<RecoItemEntity>? RecoItems { get; set; }
    }
}
