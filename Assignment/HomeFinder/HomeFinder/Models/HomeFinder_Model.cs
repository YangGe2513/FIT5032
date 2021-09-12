using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HomeFinder.Models
{
    public partial class HomeFinder_Model : DbContext
    {
        public HomeFinder_Model()
            : base("name=HomeFinder_Model")
        {
        }

        public virtual DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .Property(e => e.Size)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Property>()
                .Property(e => e.Price)
                .HasPrecision(13, 2);
        }
    }
}
