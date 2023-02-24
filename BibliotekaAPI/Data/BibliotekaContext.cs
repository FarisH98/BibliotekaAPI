using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO.Pipelines;

namespace BibliotekaAPI.Data
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext(DbContextOptions options) : base(options) { }
        public DbSet<Biblioteka> Bibliotekas { get; set; }
        public DbSet<Knjige> Knjiges { get; set; }
        public DbSet<Radnici> Radnicis { get; set; }
    }
}
