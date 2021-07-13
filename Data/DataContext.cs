using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using school_server.Models;

namespace school_server.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions<DataContext> options )
            : base( options )
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<CourseStudent>().HasKey( entity => new { entity.CourseId, entity.StudentId } );

            modelBuilder.Entity<Student>().HasData(
                new List<Student>() {
                    new Student() { Id = 1, Name = "Leonardo", Age = 30 },
                    new Student() { Id = 2, Name = "Fernando", Age = 25 }
                }
            );
            modelBuilder.Entity<Professor>().HasData(
                new List<Professor>() {
                    new Professor() { Id = 1, Name = "Adriano", Age = 42 },
                    new Professor() { Id = 2, Name = "Marisa", Age = 39 }
                }
            );
            modelBuilder.Entity<Course>().HasData(
                new List<Course>() {
                    new Course() { Id = 1, Name = "Otimização", ProfessorId = 2 },
                    new Course() { Id = 2, Name = "Controle", ProfessorId = 1 }
                }
            );
            modelBuilder.Entity<CourseStudent>().HasData(
                new List<CourseStudent>() {
                    new CourseStudent() { CourseId = 1, StudentId = 1 },
                    new CourseStudent() { CourseId = 1, StudentId = 2 },
                    new CourseStudent() { CourseId = 2, StudentId = 1 }
                }
            );
        }
    }
}