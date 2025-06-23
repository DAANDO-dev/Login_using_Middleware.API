using Microsoft.AspNetCore.Mvc;

namespace IActionResultt.Example.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
           
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Book id should be applied
                Response.StatusCode = 400; // Bad Request
                return Content("Book id is not supplied");
            }
            // Book id can't be Empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400; // Bad Request
                return Content("book id can't be empty");
            }

            //Boook id should be between 1 and 1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                Response.StatusCode = 400; // Bad Request
                return Content("Book id can't be less then or eqiual to 0");
            }

            if (bookId > 1000)
            {
                Response.StatusCode = 400; // Bad Request
                return Content("Book id can't be greater than 1000");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == true)
            {
                Response.StatusCode = 401; // Bad Request
                return Content("User must be Authenticated");
            }

            return File(@"c:\Users\darda\Downloads\docs.pdf", "application/pdf");
        }
    }
}
