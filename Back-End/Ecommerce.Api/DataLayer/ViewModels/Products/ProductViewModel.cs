using DataLayer.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Products
{
    public class ProductViewModel : BaseViewModel
    {
        public String MainImageUrl { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Identificator { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

    }
}
