namespace FinalProject_WhatsAPPening
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Activity
    {
        [Key]//Activity class properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter a category.")]
        public string Category { get; set; }
        

        public string ImageUrl { get; set; }
        public string ImageUrlLarge { get; set; }


        [DisplayName("Website")]
        [RegularExpression(@"^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU|co)[/]?$", ErrorMessage = "Invalid website.")]
        public string Link { get; set; }
        
        [DisplayName("Venue Name")]
        [Required(ErrorMessage = "Please enter a venue name.")]
        [StringLength(50)]
        public string Venue { get; set; }

        [DisplayName("Average Price Per Person")]
        [StringLength(50)]
        public string PricePerPerson { get; set; }

        [DisplayName("Street Address")]
        [StringLength(50)]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        [StringLength(50)]
        public string City { get; set; }

        [DisplayName("State")]
        [StringLength(50)]
        public string State { get; set; }

        [DisplayName("Zip")]
        [RegularExpression(@"^\d{5}?$", ErrorMessage = "Invalid zip code.")]
        [StringLength(50)]
        public string Zip { get; set; }

        [DisplayName("Phone Number")]
        [RegularExpression(@"((\(\d{3}\))|(\d{3}-))\d{3}-\d{4}", ErrorMessage = "Invalid format.")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [DisplayName("Days Open")]
        [StringLength(50)]
        public string DaysOpen { get; set; }

        [DisplayName("Times Open")]
        [StringLength(50)]
        public string TimesOpen { get; set; }

        [DisplayName("Other")]
        [StringLength(50)]
        public string Other { get; set; }
    }
}
