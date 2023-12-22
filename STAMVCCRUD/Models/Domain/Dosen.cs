using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace STAMVCCRUD.Models.Domain
{
    public class Dosen
    {
        [Key]
        public long Nip { get; set; }
        public string Nama_Dosen { get; set; }
    }
}
