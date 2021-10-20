using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.infrastructure.Entites
{
    public class Category:EmptyBaseEntity
    {
        [Required]
        public string name { get; set; }
        public string description { get; set; }
    }
}
