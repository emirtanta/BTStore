using BTStore.Entity.Entities.Concrete;
using BTStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BTStoreWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {
        private readonly IService<Contact> _contactService;

        public ContactsController(IService<Contact> contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> ContactList()
        {
            var model = await _contactService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult ContactCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactCreate(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _contactService.AddAsync(contact);

                    await _contactService.SaveChangesAsync();

                    return RedirectToAction(nameof(ContactList));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu");
                }
            }

            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> ContactEdit(int id)
        {
            var model = await _contactService.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactEdit(int id,Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactService.Update(contact);

                    await _contactService.SaveChangesAsync();

                    return RedirectToAction(nameof(ContactList));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu");
                }
            }

            return View(contact);
        }


        [HttpGet]
        public async Task<IActionResult> ContactDelete(int id)
        {
            var model = await _contactService.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactDelete(int id,Contact contact)
        {
            try
            {
                _contactService.Delete(contact);

                await _contactService.SaveChangesAsync();

                return RedirectToAction(nameof(ContactList));
            }
            catch 
            {

                return View();
            }

            
        }

    }
}
