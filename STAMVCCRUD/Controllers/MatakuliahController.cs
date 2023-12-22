using Microsoft.AspNetCore.Mvc;
using STAMVCCRUD.Data;
using STAMVCCRUD.Models.Domain;
using STAMVCCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace STAMVCCRUD.Controllers
{
    public class MatakuliahController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public MatakuliahController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexMk(string searchString, int currentPage = 1)
        {
            var matakuliah = await mvcDbContext.Matakuliah.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                matakuliah = matakuliah.Where(d => d.Nama_MK.ToLower().Contains(searchString)).ToList();
            }

            int totalRecord = matakuliah.Count();
            int pageSize = 5;
            int totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            var viewModel = new MatakuliahViewModel
            {
                MatakuliahList = matakuliah.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = currentPage,
                TotalPages = totalPages,
                SearchString = searchString
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddMk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMk(AddMatakuliahViewModel addMatakuliahRequest)
        {
            var matakuliah = new Matakuliah()
            {
                Kode_MK = addMatakuliahRequest.Kode_MK,
                Nama_MK = addMatakuliahRequest.Nama_MK,
                Sks = addMatakuliahRequest.Sks,
            };

            await mvcDbContext.Matakuliah.AddAsync(matakuliah);
            await mvcDbContext.SaveChangesAsync();

            return RedirectToAction("IndexMk");
        }

        [Route("Matakuliah/ViewMk/{kode_mk}")]
        [HttpGet]
        public async Task<IActionResult> ViewMk(string kode_mk)
        {
            var matakuliah = await mvcDbContext.Matakuliah.FirstOrDefaultAsync(x => x.Kode_MK == kode_mk);

            if (matakuliah != null)
            {

                var viewModel = new UpdateMatakuliahViewModel()
                {
                    Kode_MK= matakuliah.Kode_MK,
                    Nama_MK = matakuliah.Nama_MK,
                    Sks = matakuliah.Sks
                };
                return View(viewModel);
            }

            return RedirectToAction("IndexMk");
        }

        [HttpPost]
        public async Task<IActionResult> ViewMk(UpdateMatakuliahViewModel model)
        {
            var matakuliah = await mvcDbContext.Matakuliah.FindAsync(model.Kode_MK);

            if (matakuliah != null)
            {
                matakuliah.Nama_MK = model.Nama_MK;
                matakuliah.Sks = model.Sks;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexMk");
            }

            return RedirectToAction("IndexMk");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMatakuliahViewModel model)
        {
            var matakuliah = mvcDbContext.Matakuliah.FindAsync(model.Kode_MK);
            if (matakuliah != null)
            {
                mvcDbContext.Matakuliah.Remove(await matakuliah);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexMk");
            }

            return RedirectToAction("IndexMk");
        }

    }
}
