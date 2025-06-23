using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ActionResultsModel.Controllers
{
    [Route("book")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Book id should be applied
                
                return BadRequest("Book id is not supplied");
            }
            // Book id can't be Empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("book id can't be empty");
            }

            //Boook id should be between 1 and 1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                return BadRequest("Book id can't be less than or equal to 0");
            }

            if (bookId > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                return StatusCode(401);
            }

            return File("/docs.pdf", "application/pdf");
        }
    }
}
