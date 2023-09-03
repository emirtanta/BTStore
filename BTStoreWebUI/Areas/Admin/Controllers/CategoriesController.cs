using BTStore.Entity.Entities.Concrete;
using BTStore.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BTStoreWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(IService<Category> categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> CategoryList()
        {
            var model = await _categoryService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ImageUpload(category);

                    await _categoryService.AddAsync(category);

                    await _categoryService.SaveChangesAsync();

                    return RedirectToAction(nameof(CategoryList));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu");
                }
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var model = await _categoryService.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(int id,Category category)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    ImageUpload(category);

                    _categoryService.Update(category);

                    await _categoryService.SaveChangesAsync();

                    return RedirectToAction(nameof(CategoryList));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu");
                }
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var model = await _categoryService.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDelete(int id,Category category)
        {
            _categoryService.Delete(category);

            await _categoryService.SaveChangesAsync();

            return RedirectToAction(nameof(CategoryList));
        }

        /// <summary>
        /// veritabanına resim ekler
        /// </summary>
        /// <returns></returns>
        private void ImageUpload(Category category)
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                var fileName = Guid.NewGuid().ToString();
                //Site/menu adındaki yere resmi ekler
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"images\categories");

                var ext = Path.GetExtension(files[0].FileName);

                //resim alanı boş değilse resimleri ekler
                if (category.Image != null)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, category.Image.TrimStart('\\'));

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

                category.Image = @"\images\categories\" + fileName + ext;
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
            Category category = new Category();

            category = _categoryService.Find(category.Id);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, category.Image.TrimStart('\\'));

            //menü silindiğinde menü resmininde silinmesini sağlar
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
    }
}
