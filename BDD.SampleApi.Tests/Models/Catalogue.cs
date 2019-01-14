using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.SampleApi.Tests.Models
{
    public class Catalogue
    {
        public string Name { get; set; }
        public bool CanRelist { get; set; }
        public string PromotionName { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}
