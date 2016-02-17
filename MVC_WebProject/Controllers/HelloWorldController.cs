using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        //public string Index()
        //{
        //    return "This is my <b>default</b> action..."; //Returns single string if index page is accessed
        //}

        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome(string name, int NumTimes = 0)
        //{
        //        return HttpUtility.HtmlEncode("Hello " + name + ", Num Times: " + NumTimes);
        //}
        public ActionResult Welcome(string name, int NumTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = NumTimes;

            return View();
        }
    }
}