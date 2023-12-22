using System.ComponentModel.DataAnnotations;

namespace STAMVCCRUD.Models.Domain
{
    public class Perkuliahan
    {
        [Key]
        public int IdPerkuliahan { get; set; }
        public int Nim { get; set; }
        public required string Kode_MK { get; set; }
        public long Nip { get; set; }
        public char Nilai { get; set; }
    }
}
