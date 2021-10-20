using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.infrastructure.Entites
{
    public class Product: EmptyBaseEntity
    {
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public Category categoryId { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string currency { get; set; }
    }
}
