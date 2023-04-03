using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CaseStudyClgXplorer.Models
{
    public class DataContext : DbContext
    {
        public DataContext():base("name=DataContext") 
        {
        }

        
        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<CaseStudyClgXplorer.Models.College> Colleges { get; set; }
    }
}