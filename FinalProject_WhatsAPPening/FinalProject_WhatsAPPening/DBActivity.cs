namespace FinalProject_WhatsAPPening
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using FinalProject_WhatsAPPening.Models;


    public partial class DBActivity : DbContext
    {
        public DBActivity()
            : base("name=DBActivity")
        {

        }

        public virtual DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
