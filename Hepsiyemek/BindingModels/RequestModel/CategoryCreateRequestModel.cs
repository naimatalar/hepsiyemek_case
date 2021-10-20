using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.BindingModels.RequestModel
{
    public class CategoryCreateRequestModel
    {
        public string productId { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
    }
}
