using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STAMVCCRUD.Data;
using STAMVCCRUD.Models;
using STAMVCCRUD.Models.Domain;

namespace STAMVCCRUD.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public MahasiswaController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexMhs(string searchString, int currentPage = 1)
        {
            var mhs = await mvcDbContext.Mahasiswa.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                mhs = mhs.Where(d => d.Nama_Mhs.ToLower().Contains(searchString)).ToList();
            }

            int totalRecord = mhs.Count();
            int pageSize = 5;
            int totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            var viewModel = new MahasiswaViewModel
            {
                MahasiswaList = mhs.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = currentPage,
                TotalPages = totalPages,
                SearchString = searchString
            };

            return View(viewModel);
        }



        [HttpGet]
        public IActionResult AddMahasiswa()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddMahasiswa(AddMahasiswaViewModel addMahasiswaRequest)
        {
            var mahasiswa = new Mahasiswa()
            {
                Nama_Mhs = addMahasiswaRequest.Nama_Mhs,
                Alamat = addMahasiswaRequest.Alamat,
                Tgl_Lahir = addMahasiswaRequest.Tgl_Lahir,
                Jenis_Kelamin = (Models.Domain.JenisKelamin)addMahasiswaRequest.Jenis_Kelamin
            };

            await mvcDbContext.Mahasiswa.AddAsync(mahasiswa);
            await mvcDbContext.SaveChangesAsync();

            return RedirectToAction("IndexMhs");
        }

        [Route("Mahasiswa/ViewMhs/{nim}")]
        [HttpGet]
        public async Task<IActionResult> ViewMhs(int nim)
        {
            var mahasiswa = await mvcDbContext.Mahasiswa.FirstOrDefaultAsync(x => x.Nim == nim);

            if (mahasiswa != null)
            {

                var viewModel = new UpdateMhsViewModel()
                {
                    Nim = nim,
                    Nama_Mhs = mahasiswa.Nama_Mhs,
                    Alamat = mahasiswa.Alamat,
                    Tgl_Lahir = mahasiswa.Tgl_Lahir,
                    Jenis_Kelamin = (Models.JenisKelamin)mahasiswa.Jenis_Kelamin
                };
                return View(viewModel);
            }

            return RedirectToAction("IndexMhs");
        }

        [HttpPost]
        public async Task<IActionResult> ViewMhs(UpdateMhsViewModel model)
        {
            var mahasiswa = await mvcDbContext.Mahasiswa.FindAsync(model.Nim);

            if (mahasiswa != null)
            {
                mahasiswa.Nama_Mhs = model.Nama_Mhs;
                mahasiswa.Tgl_Lahir = model.Tgl_Lahir;
                mahasiswa.Alamat = model.Alamat;
                mahasiswa.Jenis_Kelamin = (Models.Domain.JenisKelamin)model.Jenis_Kelamin;
                
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexMhs");
            }

            return RedirectToAction("IndexMhs");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMhsViewModel model)
        {
            var mahasiswa = mvcDbContext.Mahasiswa.FindAsync(model.Nim);
            if (mahasiswa != null)
            {
                mvcDbContext.Mahasiswa.Remove(await mahasiswa);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("IndexMhs");
            }

            return RedirectToAction("IndexMhs");
        }


        }
}
