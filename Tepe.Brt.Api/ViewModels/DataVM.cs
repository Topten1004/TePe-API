using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tepe.Brt.Api.ViewModels
{
    public class DataVM
    {
        public string? email { get; set; }

        public string? phone_number { get; set; }

        public string? comment { get; set; }

        public string? recommendations { get; set; } = string.Empty;

        public List<int> missing { get; set; } = new List<int>();

        public List<int> bridge { get; set; } = new List<int>();

        public string? teeth_image { get; set; }
    }
}
