namespace Tepe.Brt.Api.ViewModels
{
    public class PatientVM
    {
        public PatientVM()
        {
            Recommendations = new List<RecommendationVM>();
        }

        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public virtual IEnumerable<RecommendationVM> Recommendations { get; set; }
    }
}
