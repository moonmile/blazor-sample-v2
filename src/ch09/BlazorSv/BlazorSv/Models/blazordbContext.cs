using System;
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