using DataLayer.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Brands
{
    public class BrandViewModel : BaseViewModel
    {
        public string Identificator { get; set; }
        public string Description { get; set; }
    }
}
