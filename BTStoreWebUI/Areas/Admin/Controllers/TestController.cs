using BTStore.Entity.Entities.Concrete;
using BTStore.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BTStoreWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
