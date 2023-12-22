using Microsoft.EntityFrameworkCore;
using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Mahasiswa> Mahasiswa { get; set; }

        public DbSet<Matakuliah> Matakuliah { get; set; }

        public DbSet<Dosen> Dosen { get; set; }

        public DbSet<Perkuliahan> Perkuliahan { get; set; }
    }
}
