using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Cuisine")]
        public List<string> CuisineTypes { get; set; }

        [DisplayName("Price Range")]
        public PriceRange PriceRange { get; set; }

        [DisplayName("Description")]
        public List<string> Description { get; set; }

        [DisplayName("Street Address")]
        public string Address { get; set; }

        [DisplayName("Hours")]
        public string Hours { get; set; }

        [DisplayName("Zip")]
        public int? ZipCode { get; set; }

        [DisplayName("Website")]
        public string Website { get; set; }
    }

    public enum PriceRange
    {
        Cheap = 1,
        Moderate,
        High,
        Expensive,
        VeryExpensive
    }
}