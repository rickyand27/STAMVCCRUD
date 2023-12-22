using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STAMVCCRUD.Models
{
    public enum JenisKelamin
    {
        LakiLaki,
        Perempuan
    }
    public class AddMahasiswaViewModel
    {   
        public required string Nama_Mhs { get; set; }
        public DateTime Tgl_Lahir { get; set; }
        public required string Alamat { get; set; }
        public required JenisKelamin Jenis_Kelamin { get; set; }
     }
   
}
