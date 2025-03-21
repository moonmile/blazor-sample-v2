using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorWebApiClientSameSv.Models
{
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
    }
}
