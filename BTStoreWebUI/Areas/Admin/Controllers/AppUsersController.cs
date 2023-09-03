using BTStore.Entity.Entities.Concrete;
using BTStore.Service.Interfaces;
using BTStore.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BTStoreWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUsersController : Controller
    {
        private readonly IService<AppUser> _service;

        public AppUsersController(IService<AppUser> service)
        {
            _service = service;
        }

        public async Task<IActionResult> UserList()
        {
            var model =await _service.GetAllAsync();

            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(AppUser appuser)
        {
            try
            {
                await _service.AddAsync(appuser);

                await _service.SaveChangesAsync();

                return RedirectToAction(nameof(UserList));
            }
            catch
            {

                ModelState.AddModelError("", "hata oluştu!!");
            }

            return View(appuser);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(int id, AppUser appUser)
        {
            try
            {
                _service.Update(appUser);

                await _service.SaveChangesAsync();

                return RedirectToAction(nameof(UserList));
            }
            catch
            {

                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> UserDelete(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDelete(int id, AppUser appUser)
        {
            try
            {
                var model = await _service.FindAsync(id);
                _service.Delete(model);

                await _service.SaveChangesAsync();

                return RedirectToAction(nameof(UserList));
            }
            catch
            {

                return View();
            }
        }
    }
}
