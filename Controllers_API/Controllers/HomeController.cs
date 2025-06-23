using Microsoft.AspNetCore.Mvc;
using Controllers_API.Models;


namespace Controllers_API.Controllers
{
    [Controller]

    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {


        [Route("Home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");

        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };
            //return new JsonResult(person);
            return Json(person);

        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
           // return new VirtualFileResult("/docs.pdf",
              //  "application/pdf")
              return File("/docs.pdf", "application/pdf");
        }


        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"c:\Users\darda\Downloads\docs.pdf", "application/pdf");
            return PhysicalFile(@"c:\Users\darda\Downloads\docs.pdf", "application/pdf");
        }


        [Route("file-download3")]
        public IActionResult FileDownload3() // Low level format
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"c:\Users\darda\Downloads\docs.pdf");
            return File(bytes, "application/pdf");
           
        }

    } 

}
