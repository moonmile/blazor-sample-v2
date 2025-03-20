using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSvMySql.Models;


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
        => optionsBuilder.UseMySQL("server=localhost;user id=blazor;password=blazor;database=blazordb;port=3306;sslmode=None");

}