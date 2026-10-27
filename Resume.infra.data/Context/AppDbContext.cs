using Microsoft.EntityFrameworkCore;
using Resume.Application.Context;
using Resume.Domain.Models;

namespace Resume.Infra.Data.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    #region Constructor

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    #endregion

    #region Dbset

    public DbSet<ThingIDo> ThingIDos { get; set; }

    public DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }

    public DbSet<CustomerLogo> CustomerLogos { get; set; }

    public DbSet<Education> Educations { get; set; }

    public DbSet<Experience> Experiences { get; set; }

    public DbSet<Skill> Skills { get; set; }

    public DbSet<Portfolio> Portfolios { get; set; }

    public DbSet<PortfolioCategory> PortfolioCategories { get; set; }

    public DbSet<SocialMedia> SocialMedias { get; set; }

    public DbSet<Information> Informations { get; set; }

    public DbSet<Message> Messages { get; set; }

    public DbSet<User> Users { get; set; }

    #endregion

    #region On Model Creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // For Delete Base Table On Child Tables When Deleted 
        foreach (var relationships in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationships.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Username).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
