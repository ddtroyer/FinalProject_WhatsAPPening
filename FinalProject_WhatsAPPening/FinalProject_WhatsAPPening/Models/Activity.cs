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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public string Link { get; set; }

        [Required]
        [StringLength(50)]
        public string Venue { get; set; }

        [StringLength(50)]
        public string PricePerPerson { get; set; }

        [StringLength(50)]
        public string StreetAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Zip { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string DaysOpen { get; set; }

        [StringLength(50)]
        public string TimesOpen { get; set; }
    }
}
