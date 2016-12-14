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

        //[StringLength(50)]
        //[Required(ErrorMessage = "Please enter a category.")]
        
        public string Category { get; set; }

        [DisplayName("Website")]
        [RegularExpression(@"^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$", ErrorMessage = "Invalid website.")]
        public string Link { get; set; }

        
        [DisplayName("Venue Name")]
        //[Required(ErrorMessage = "Please enter a venue name.")]
        //[StringLength(50)]
        public string Venue { get; set; }

        [DisplayName("Average Price Per Person")]
        //[Required(ErrorMessage = "Please enter the average price per person.")]
        //[StringLength(50)]
        public string PricePerPerson { get; set; }

        [DisplayName("Street Address")]
        //[StringLength(50)]
        public string StreetAddress { get; set; }

        //[StringLength(50)]
        public string City { get; set; }

        //[StringLength(50)]
        public string State { get; set; }

        [DisplayName("Zip")]
        [StringLength(50)]
        public string Zip { get; set; }

        [DisplayName("Phone Number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [DisplayName("Days Open")]
        //[StringLength(50)]
        public string DaysOpen { get; set; }

        [DisplayName("Times Open")]
        //[StringLength(50)]
        public string TimesOpen { get; set; }

        [DisplayName("Other")]
        //[Required(ErrorMessage = "Enter additional applicable notes here.")]
        //[StringLength(50)]
        public string Other { get; set; }
    }
}
