using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSv.Models;

public partial class BlazordbContext : DbContext
{
    public BlazordbContext()
    {
    }

    public BlazordbContext(DbContextOptions<BlazordbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Books> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=blazordb;Trusted_connection=True;TrustServerCertificate=Yes");

}

public interface IDbContextFactory<TContext> where TContext : DbContext
{
    TContext CreateDbContext();
}

public class blazordbFactory<TContext>
    : IDbContextFactory<TContext> where TContext : DbContext
{
    public blazordbFactory(IServiceProvider provider)
    {
        this.provider = provider;
    }
    private readonly IServiceProvider provider;
    public TContext CreateDbContext()
    {
        return ActivatorUtilities.CreateInstance<TContext>(provider);
    }
}

#if false
    public static class FactoryExtensions
    {
        public static IServiceCollection AddDbContextFactory<TContext>(
            this IServiceCollection collection,
            Action<DbContextOptionsBuilder>? optionsAction = null,
            ServiceLifetime contextAndOptionsLifetime = ServiceLifetime.Singleton)
            where TContext : DbContext
        {
            collection.Add(new ServiceDescriptor(
                typeof(IDbContextFactory<TContext>),
                sp => new blazordbFactory<TContext>(sp),
                contextAndOptionsLifetime));
            collection.Add(new ServiceDescriptor(
                typeof(DbContextOptions<TContext>),
                sp => GetOptions<TContext>(optionsAction, sp),
                contextAndOptionsLifetime));

            return collection;
        }
        private static DbContextOptions<TContext> GetOptions<TContext>(
            Action<DbContextOptionsBuilder> action,
            IServiceProvider? sp = null) where TContext : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            if (sp != null)
            {
                optionsBuilder.UseApplicationServiceProvider(sp);
            }
            action?.Invoke(optionsBuilder);
            return optionsBuilder.Options;
        }
    }
#endif



