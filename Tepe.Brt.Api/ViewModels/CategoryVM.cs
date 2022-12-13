using System.ComponentModel.DataAnnotations.Schema;

namespace Tepe.Brt.Api.ViewModels
{
    public class CategoryVM
    {
        
        public CategoryVM()
        {
            Markets = new List<MarketVM>();

            Products = new List<ProductVM>();
        }


        public string? Title { get; set; }
        [NotMapped]
        public string? catImage { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public virtual IEnumerable<MarketVM> Markets { get; set; }
        [NotMapped]
        public virtual IEnumerable<ProductVM> Products { get; set; }
    }
}
