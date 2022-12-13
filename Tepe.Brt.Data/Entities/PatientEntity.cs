using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tepe.Brt.Data.Entities
{
    [Table("Patients")]
    public class PatientEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public virtual ICollection<RecommendationEntity> Recommendations { get; set; }
    }
}
