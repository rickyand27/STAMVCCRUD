using System.ComponentModel.DataAnnotations;

namespace STAMVCCRUD.Models.Domain
{
    public enum JenisKelamin
    {
        LakiLaki,
        Perempuan
    }

    public class Mahasiswa
    {
        [Key]
        public int Nim { get; set; }
        public required string Nama_Mhs { get; set; }
        public DateTime Tgl_Lahir { get; set; }
        public required string Alamat { get; set; }
        public JenisKelamin Jenis_Kelamin { get; set; }
    }
}
