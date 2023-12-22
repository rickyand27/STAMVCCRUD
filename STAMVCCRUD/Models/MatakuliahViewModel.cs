using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Models
{
    public class MatakuliahViewModel
    {
        public List<Matakuliah> MatakuliahList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }

    }
}
