namespace Standups2.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Standups2.Models;

    public partial class SUPContext : DbContext
    {
        public SUPContext()
            : base("name=SUPContext")
        {
        }

        public virtual DbSet<SUPAcademicYear> SUPAcademicYears { get; set; }
        public virtual DbSet<SUPAdvisor> SUPAdvisors { get; set; }
        public virtual DbSet<SUPGroup> SUPGroups { get; set; }
        public virtual DbSet<SUPMeeting> SUPMeetings { get; set; }
        public virtual DbSet<SUPUser> SUPUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SUPAcademicYear>()
                .Property(e => e.Year)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SUPAcademicYear>()
                .HasMany(e => e.SUPGroups)
                .WithRequired(e => e.SUPAcademicYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUPUser>()
                .HasMany(e => e.SUPMeetings)
                .WithRequired(e => e.SUPUser)
                .WillCascadeOnDelete(false);
        }
    }
}
