﻿using Microsoft.EntityFrameworkCore;

namespace IreckonuDataImporter.DAL
{
    public class ArtikelStoreContext : DbContext
    {
        public DbSet<Artikel> Artikels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // WARNING: To protect potentially sensitive information in your connection string, this should be moved out from source code.
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=ArtikelStore;Trusted_Connection=True;");
        }
    }
}
