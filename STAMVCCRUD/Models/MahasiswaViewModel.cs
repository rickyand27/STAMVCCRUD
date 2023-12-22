using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Models
{
    public class MahasiswaViewModel
    {
        public List<Mahasiswa> MahasiswaList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }
    }
}
