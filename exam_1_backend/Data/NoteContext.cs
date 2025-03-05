using Microsoft.EntityFrameworkCore;
using System;
using exam_1_backend.Models;

namespace exam_1_backend.Data
{
    public class NoteContext : DbContext
    {
        private string connectionString = "Server=tcp:cloud-exam-one-server.database.windows.net,1433;Initial Catalog=exam-one-ryo;Persist Security Info=False;User ID=service;Password=WildCat123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Note");
        }

        public DbSet<Note> Note { get; set; }
    }
}
