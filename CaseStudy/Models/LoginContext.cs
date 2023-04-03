using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseStudy.Models
{
    public class LoginContext : DbContext
    {
        public DbSet<tblLogin> tblLogins { get; set; }
        public DbSet<User> userss { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
    }
}