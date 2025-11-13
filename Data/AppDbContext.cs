using LabProjectTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LabProjectTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
