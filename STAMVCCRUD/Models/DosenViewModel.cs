using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Models
{
    public class DosenViewModel
    {
        public List<Dosen> DosenList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }
    }
}
