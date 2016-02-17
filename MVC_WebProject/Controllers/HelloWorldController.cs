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

        public string Welcome(string name, int Age = 0)
        {
            if (Age != 0)
            {
                return HttpUtility.HtmlEncode("Hello " + name + ", You are: " + Age + "years old...");
            } else
            {
                return HttpUtility.HtmlEncode("Hello " + name + ", You never told me how old you are...");
            }
        }
    }
}