using Differ.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Differ.Infra.Data.Context
{
    public sealed class DifferContext : DbContext
    {
        public DifferContext(DbContextOptions<DifferContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

            if (Database.GetPendingMigrations().Count() > 0)
            {
                Database.Migrate();
            }
        }

        public DbSet<Diff> Diffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}