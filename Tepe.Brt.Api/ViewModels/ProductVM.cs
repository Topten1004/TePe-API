using System.ComponentModel.DataAnnotations;

namespace Tepe.Brt.Api.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            Category = new CategoryVM();
        }

        public string? Name { get; set; }

        public string? Size { get; set; }

        public string? Hex { get; set; }

        public Guid CategoryID { get; set; }

        public CategoryVM Category { get; set; }
    }
}
