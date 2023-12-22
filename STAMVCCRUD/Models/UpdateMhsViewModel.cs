using System.ComponentModel.DataAnnotations;

namespace STAMVCCRUD.Models
{
    public class UpdateMhsViewModel
    {
        public int Nim { get; set; }
        public required string Nama_Mhs { get; set; }
        public DateTime Tgl_Lahir { get; set; }
        public required string Alamat { get; set; }
        public JenisKelamin Jenis_Kelamin { get; set; }
    }
    
}
