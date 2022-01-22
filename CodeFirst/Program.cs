using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Courses")]
    public class Course
    {
        public Course()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }

        public int? Author_Id { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }

        public PlutoContext() : base("name=DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Author)
                .HasForeignKey(e => e.Author_Id);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("TagCourses").MapLeftKey("Course_Id"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
