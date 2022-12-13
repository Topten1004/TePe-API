using System.ComponentModel.DataAnnotations;

namespace Tepe.Brt.Data.Entities
{
    public class RecoItemEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Area { get; set; }

        public Guid RecommendationID { get; set; }

        public RecommendationEntity? Recommendation { get; set; }
    }
}
