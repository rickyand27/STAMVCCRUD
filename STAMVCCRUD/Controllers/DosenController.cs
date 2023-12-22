using Microsoft.AspNetCore.Mvc;
using STAMVCCRUD.Data;
using STAMVCCRUD.Models.Domain;
using STAMVCCRUD.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace STAMVCCRUD.Controllers
{
    public class DosenController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public DosenController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexDosen(string searchString, int currentPage = 1)
        {
            var dosen = await mvcDbContext.Dosen.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                dosen = dosen.Where(d => d.Nama_Dosen.ToLower().Contains(searchString)).ToList();
            }

            int totalRecord = dosen.Count();
            int pageSize = 5;
            int totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            var viewModel = new DosenViewModel
            {
                DosenList = dosen.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = currentPage,
                TotalPages = totalPages,
                SearchString = searchString
            };

            return View(viewModel);
        }






        [HttpGet]
        public IActionResult AddDosen()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDosen(AddDosenViewModel addDosenRequest)
        {
            var dosen = new Dosen()
            {
                Nip = addDosenRequest.Nip,
                Nama_Dosen = addDosenRequest.Nama_Dosen
            };

            await mvcDbContext.Dosen.AddAsync(dosen);
            await mvcDbContext.SaveChangesAsync();

            return RedirectToAction("IndexDosen");
        }

        [Route("Dosen/ViewDosen/{nip}")]
        [HttpGet]
        public async Task<IActionResult> ViewDosen(long nip)
        {
            var dosen = await mvcDbContext.Dosen.FirstOrDefaultAsync(x => x.Nip == nip);

            if (dosen != null)
            {

                var viewModel = new UpdateDosenViewModel()
                {
                    Nip = nip,
                    Nama_Dosen = dosen.Nama_Dosen,
                };
                return View(viewModel);
            }

            return RedirectToAction("IndexDosen");
        }

        [HttpPost]
        public async Task<IActionResult> ViewDosen(UpdateDosenViewModel model)
        {
            var dosen = await mvcDbContext.Dosen.FindAsync(model.Nip);

            if (dosen != null)
            {
                dosen.Nama_Dosen = model.Nama_Dosen;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexDosen");
            }

            return RedirectToAction("IndexMhs");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateDosenViewModel model)
        {
            var dosen = mvcDbContext.Dosen.FindAsync(model.Nip);
            if (dosen != null)
            {
                mvcDbContext.Dosen.Remove(await dosen);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexDosen");
            }

            return RedirectToAction("IndexDosen");
        }
    }
}
