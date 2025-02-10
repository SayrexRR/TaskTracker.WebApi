using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.ProjectName)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.HasMany(p => p.TaskItems)
                    .WithOne(ti => ti.Project)
                    .HasForeignKey(ti => ti.ProjectId);
                entity.HasMany(p => p.Users)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("ProjectUsers"));
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasMany(c => c.Tasks)
                    .WithOne(ti => ti.Category)
                    .HasForeignKey(ti => ti.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(ti => ti.Id);
                entity.Property(ti => ti.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(ti => ti.Priority)
                    .IsRequired()
                    .HasDefaultValue(2);
                entity.HasOne(ti => ti.AssignedTo)
                    .WithMany()
                    .HasForeignKey(ti => ti.AssignedToId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
