using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator.Models;

namespace Calculator.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(string number1, string number2)
    {
      var isNumericOne = int.TryParse(number1, out int numberOne);
      var isNumericTwo = int.TryParse(number2, out int numberTwo);
      // int numberOne = int.Parse(number1);
      // int numberTwo = int.Parse(number2);
      if (isNumericOne && isNumericTwo)
      {
        if (numberOne > 0 && numberTwo > 0)
        {
          double root1 = Math.Sqrt(numberOne);
          double root2 = Math.Sqrt(numberTwo);
          int sum = numberTwo + numberTwo;

          // return the roots values to the View
          ViewBag.root1 = root1;
          ViewBag.root2 = root2;

          ViewBag.Result = sum;
          // return the numbers values to the View
          ViewBag.numberOne = numberOne;
          ViewBag.numberTwo = numberTwo;
        }
        else
        {
          ViewBag.error = "You have Negative Number(s) Supplied! Please enter Positive Integers Only";
        }
      }
      else
      {
        ViewBag.error = "Please Enter Integers Only! No Text or Decimals Allowed";
      }



      return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
