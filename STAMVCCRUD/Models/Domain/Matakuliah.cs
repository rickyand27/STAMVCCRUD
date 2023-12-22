using System.ComponentModel.DataAnnotations;

namespace STAMVCCRUD.Models.Domain
{
    public class Matakuliah
    {
        [Key]
        public required string Kode_MK { get; set; }
        public required string Nama_MK { get; set; }
        public int Sks { get; set; }
    }
}
