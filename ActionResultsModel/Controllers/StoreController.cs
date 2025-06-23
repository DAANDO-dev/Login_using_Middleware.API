using Microsoft.AspNetCore.Mvc;

namespace ActionResultsModel.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/book")]
        public IActionResult Books()
        {
            return View();
        }
    }
}
