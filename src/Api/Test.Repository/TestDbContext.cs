using Microsoft.EntityFrameworkCore;
using Test.Entities.Models;


namespace Test.Repository;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Section>? Sections { get; set; }
    public DbSet<Subsection>? Subsections { get; set; }
    public DbSet<Facet>? Facets { get; set; }
    public DbSet<ArticleFacet>? ArticleFacets { get; set; }
    public DbSet<ImageFormat>? ImageFormats { get; set; }
    public DbSet<Article>? Articles { get; set; }
    public DbSet<Multimedia>? Multimedias { get; set; }
}