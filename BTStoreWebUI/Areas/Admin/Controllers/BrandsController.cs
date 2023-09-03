using BTStore.Entity.Entities.Concrete;
using BTStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;

namespace BTStoreWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IService<Brand> _brandService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandsController(IService<Brand> brandService, IWebHostEnvironment webHostEnvironment)
        {
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> BrandList()
        {
            var model = await _brandService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult BrandCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrandCreate(Brand brand)
        {
            if (ModelState.IsValid)
            {
               // await ImageUpload();

                try
                {
                    ImageUpload(brand);

                    await _brandService.AddAsync(brand);

                    await _brandService.SaveChangesAsync();

                    return RedirectToAction(nameof(BrandList));
                }
                catch
                {

                    ModelState.AddModelError("", "Hata Oluştu!!");
                }
            }

            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> BrandEdit(int id)
        {
            var model = await _brandService.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrandEdit(int id, Brand brand)
        {
            if (ModelState.IsValid)
            {
                 
                try
                {
                    ImageUpload(brand);

                    _brandService.Update(brand);

                    await _brandService.SaveChangesAsync();

                    return RedirectToAction(nameof(BrandList));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!!");
                }
            }

            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> BrandDelete(int id)
        {
            var model = await _brandService.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BrandDelete(int id, Brand brand)
        {
            try
            {
                //brand = await _brandService.FindAsync(id);

                //var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, brand.Image.TrimStart('\\'));

                ////menü silindiğinde menü resmininde silinmesini sağlar
                //if (System.IO.File.Exists(imagePath))
                //{
                //    System.IO.File.Delete(imagePath);
                //}

                _brandService.Delete(brand);

                

                await _brandService.SaveChangesAsync();

                return RedirectToAction(nameof(BrandList));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// veritabanına resim ekler
        /// </summary>
        /// <returns></returns>
        private void ImageUpload(Brand brand)
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                var fileName = Guid.NewGuid().ToString();
                //Site/menu adındaki yere resmi ekler
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"images\brands");

                var ext = Path.GetExtension(files[0].FileName);

                //resim alanı boş değilse resimleri ekler
                if (brand.Image != null)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, brand.Image.TrimStart('\\'));

                    //menü silindiğinde menü resmininde silinmesini sağlar
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                {
                    files[0].CopyTo(filesStreams);
                }

                brand.Image = @"\images\brands\" + fileName + ext;
            }
        }

        /// <summary>
        /// resmi veritabanından siler
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        private void ImageDeleteToDatabase()
        {
            Brand brand = new Brand();

            brand =  _brandService.Find(brand.Id);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, brand.Image.TrimStart('\\'));

            //menü silindiğinde menü resmininde silinmesini sağlar
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
    }
}
