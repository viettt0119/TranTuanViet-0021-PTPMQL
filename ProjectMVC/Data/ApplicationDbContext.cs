using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models.Entities;

namespace ProjectMVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Faculty> Faculties { get; set; } = default!;
    public DbSet<Student> Students { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Faculty>().HasData(
            new Faculty { FacultyID = 1, FacultyName = "Cong nghe thong tin" },
            new Faculty { FacultyID = 2, FacultyName = "Quan tri kinh doanh" },
            new Faculty { FacultyID = 3, FacultyName = "Ngon ngu Anh" });

        modelBuilder.Entity<Student>()
            .HasOne(student => student.Faculty)
            .WithMany(faculty => faculty.Students)
            .HasForeignKey(student => student.FacultyID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
