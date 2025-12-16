using Microsoft.EntityFrameworkCore;
using Flora.Api.Domain;

namespace Flora.Api.Data
{
    public class FloraDbContext : DbContext
    {
        public FloraDbContext(DbContextOptions<FloraDbContext> options) : base(options)
        {
        }

        public DbSet<Species> Species { get; set; }
        public DbSet<Taxonomy> Taxonomies { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Sequence> Sequences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Species configuration
            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ScientificName).IsRequired();
                entity.HasOne(e => e.Taxonomy)
                    .WithMany(t => t.Species)
                    .HasForeignKey(e => e.TaxonomyId);
            });

            // Taxonomy configuration
            modelBuilder.Entity<Taxonomy>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId);
            });

            // Translation configuration
            modelBuilder.Entity<Translation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Species)
                    .WithMany(s => s.Translations)
                    .HasForeignKey(e => e.SpeciesId);
            });

            // Distribution configuration
            modelBuilder.Entity<Distribution>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Species)
                    .WithMany(s => s.Distributions)
                    .HasForeignKey(e => e.SpeciesId);
            });

            // Media configuration
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Species)
                    .WithMany(s => s.Media)
                    .HasForeignKey(e => e.SpeciesId);
            });

            // Sequence configuration
            modelBuilder.Entity<Sequence>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Species)
                    .WithMany(s => s.Sequences)
                    .HasForeignKey(e => e.SpeciesId);
            });
        }
    }
}
