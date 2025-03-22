using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author {  get; set; }
        public string ISBN { get; set; }

        [Display(Name ="Last Price")]
        public double ListPrice {  get; set; }
        [Display(Name = "Price for 1-50 Books")]
        public double Price { get; set; }
        [Display(Name = "Price for 50-100 Books")]
        public double Price50 {  get; set; }
        [Display(Name = "Price for 100+ Books")]
        public double Price100 { get; set; }
    }
}
