using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STAMVCCRUD.Data;
using STAMVCCRUD.Models;
using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Controllers
{
    public class PerkuliahanController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public PerkuliahanController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexPerkuliahan(string searchString, int currentPage = 1)
        {
            var perkuliahan = await mvcDbContext.Perkuliahan.ToListAsync();

            if (!string.IsNullOrEmpty(searchString) && int.TryParse(searchString, out var searchInt))
            {
                perkuliahan = perkuliahan.Where(d => d.Nim == searchInt).ToList();
            }

            int totalRecord = perkuliahan.Count();
            int pageSize = 5;
            int totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            var viewModel = new PerkuliahanViewModel
            {
                PerkuliahanList = perkuliahan.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = currentPage,
                TotalPages = totalPages,
                SearchString = searchString
            };

            return View(viewModel);
        }




        [HttpGet]
        public IActionResult AddPerkuliahan()
        {

            var mahasiswaList = mvcDbContext.Mahasiswa
                  .Select(m => new
                  {
                      Nim = m.Nim,
                      NimNama = m.Nim + " - " + m.Nama_Mhs
                  })
                   .ToList();

            var matakuliahList = mvcDbContext.Matakuliah
                .Select(m => new
                {
                    Kode_MK = m.Kode_MK,
                    KodeNama = m.Kode_MK + " - " + m.Nama_MK
                }).ToList();
            var dosenList = mvcDbContext.Dosen
                .Select(m => new
                {
                    Nip = m.Nip,
                    NipNama = m.Nip + " - " + m.Nama_Dosen
                }).ToList();

            ViewBag.MahasiswaList = new SelectList(mahasiswaList, "Nim", "NimNama");
            ViewBag.MatakuliahList = new SelectList(matakuliahList, "Kode_MK", "KodeNama");
            ViewBag.DosenList = new SelectList(dosenList, "Nip", "NipNama");

            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> AddPerkuliahan(AddPerkuliahanViewModel addPerkuliahanRequest)
        {
            var perkuliahan = new Perkuliahan()
            {
                Nim = addPerkuliahanRequest.Nim,
                Kode_MK = addPerkuliahanRequest.Kode_MK,
                Nip = addPerkuliahanRequest.Nip,
                Nilai = addPerkuliahanRequest.Nilai
            };

            await mvcDbContext.Perkuliahan.AddAsync(perkuliahan);
            await mvcDbContext.SaveChangesAsync();

            return RedirectToAction("IndexPerkuliahan");
        }

        [Route("Perkuliahan/ViewPerkuliahan/{idPerkuliahan}")]
        [HttpGet]
        public async Task<IActionResult> ViewPerkuliahan(int idPerkuliahan)
        {
            var perkuliahan = await mvcDbContext.Perkuliahan.FirstOrDefaultAsync(x => x.IdPerkuliahan == idPerkuliahan);

            if (perkuliahan != null)
            {

                var viewModel = new UpdatePerkuliahanViewModel()
                {
                    Nim = perkuliahan.Nim,
                    Kode_MK = perkuliahan.Kode_MK,
                    Nip = perkuliahan.Nip,
                    Nilai = perkuliahan.Nilai
                };
                return View(viewModel);
            }

            return RedirectToAction("IndexPerkuliahan");
        }

        [HttpPost]
        public async Task<IActionResult> ViewPerkuliahan(Perkuliahan pkl)
        {
            var perkuliahan = await mvcDbContext.Perkuliahan.FindAsync(pkl.IdPerkuliahan);

            if (perkuliahan != null)
            {
                perkuliahan.IdPerkuliahan = pkl.IdPerkuliahan;
                perkuliahan.Nim = pkl.Nim;
                perkuliahan.Kode_MK = pkl.Kode_MK;
                perkuliahan.Nip = pkl.Nip;
                perkuliahan.Nilai = pkl.Nilai;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexPerkuliahan");
            }
            return RedirectToAction("IndexPerkuliahan");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePerkuliahanViewModel model)
        {
            var perkuliahan = mvcDbContext.Perkuliahan.FindAsync(model.IdPerkuliahan);
            if (await perkuliahan != null)
            {
                mvcDbContext.Perkuliahan.Remove(await perkuliahan);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexPerkuliahan");
            }

            return RedirectToAction("IndexPerkuliahan");
        }
    }
}
