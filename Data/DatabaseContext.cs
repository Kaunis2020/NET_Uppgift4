using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uppgift4.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().HasOne(d=>d.CD).WithOne().OnDelete(DeleteBehavior.ClientCascade);
    }

    public DbSet<Artist> Artist { get; set; }

    public DbSet<Song> Song { get; set; }

    public DbSet<CD> CD { get; set; }
}
