using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FinalProject_WhatsAPPening.Models;

namespace FinalProject_WhatsAPPening
{
    public class ResultContext:DbContext
    {
        public DbSet<ResultViewModel> Results { get; set; }
    }
}