using DataAnnotations.EntityConfigurations;
using System.Data.Entity;

namespace DataAnnotations
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());

            //modelBuilder
            //    .Entity<Author>()
            //    .HasMany(a => a.Courses)
            //    .WithRequired(c => c.Author)
            //    .HasForeignKey(c => c.AuthorId);

            //modelBuilder
            //    .Entity<Course>()
            //    .HasMany(c => c.Tags)
            //    .WithMany(t => t.Courses)
            //    .Map(m => m.ToTable("CourseTags"));
        }
    }
}