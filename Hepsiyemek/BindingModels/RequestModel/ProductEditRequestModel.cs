using Hepsiyemek.infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.BindingModels.RequestModel
{
    public class ProductEditRequestModel
    {
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public CategoryCreateRequestModel categoryId { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string currency { get; set; }
    }
}
