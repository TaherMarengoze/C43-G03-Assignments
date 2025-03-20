using Microsoft.AspNetCore.Mvc;

namespace C43_G03_MVC02.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Products() => View();

    public IActionResult Orders() => View();

    public IActionResult ContactUs() => View();

    
    public IActionResult AboutMe() => Redirect("https://www.google.com/ncr"); //Test Redirection
}