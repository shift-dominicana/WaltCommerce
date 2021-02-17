using Common.Models.Core;

namespace Common.Models.ProductsColors
{
    public class ProductColor : BaseModel
    {
        public string HexCode { get; set; }
        public string Description { get; set; }
        public string ImageColorUrl { get; set; }
    }
}
