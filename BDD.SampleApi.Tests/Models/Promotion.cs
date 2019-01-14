using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.SampleApi.Tests.Models
{
    public class Promotion
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string OriginalPrice { get; set; }
        public string Recommended { get; set; }
        public string MinimumPhotoCount { get; set; }
    }
}
