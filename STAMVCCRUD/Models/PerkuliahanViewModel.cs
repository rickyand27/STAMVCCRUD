using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Models
{
    public class PerkuliahanViewModel
    {

        public List<Perkuliahan> PerkuliahanList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }
    }
}
