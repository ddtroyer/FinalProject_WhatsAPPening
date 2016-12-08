namespace FinalProject_WhatsAPPening
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Activity
    {
        //Activity class properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public string Image { get; set; }

        public string Link { get; set; }

        [Required]
        [StringLength(50)]
        public string Venue { get; set; }

        [Required]
        [StringLength(50)]
        public string PricePerPerson { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Zip { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string MovieName { get; set; }

        [StringLength(50)]
        public string MovieDescription { get; set; }

        [StringLength(50)]
        public string StartTime { get; set; }

        [StringLength(50)]
        public string LengthOfTime { get; set; }

        [StringLength(50)]
        public string DaysOpen { get; set; }

        [StringLength(50)]
        public string TimesOpen { get; set; }
    }
}
