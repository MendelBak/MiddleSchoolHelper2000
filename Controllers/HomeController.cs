using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading;
using Microsoft.Office.Interop.Word;


namespace MiddleSchoolHelper.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitLines")]
        // The way that I'm passing in the response from the form is terrible. Ideally I should use a View Model. I'm on the train now so don't want to do that, but I definitely need to change how this works.
        public IActionResult SubmitLines(string lines, int numLines = 1)
        {
            // Function scope variable declarations

            //Contains a list of imported fonts.
            List<string> FontList = new List<string>();

            StringBuilder CompletedString = new StringBuilder();

            // Chooses a random font from the list.
            int RandomFont = 0;
            Random rand = new Random();

            // Add various fonts into FontList (fonts are imported in the _Layout.cshtml page header)
            FontList.Add("Shadows Into Light, cursive");
            FontList.Add("Shadows Into Light Two, cursive");
            FontList.Add("Give You Glory, cursive");
            FontList.Add("The Girl Next Door, cursive");

            // This loop performs the actual creation of the string depending on the num of lines the user set.
            for (int j = 0; j < numLines; j++)
            {
                for (var k = 0; k < lines.Length; k++)
                {
                    RandomFont = rand.Next(0, 4);
                    CompletedString.Append($"<span style=\"font-family:{FontList[RandomFont]}\">" + lines[k] + "</span>");
                    if (lines[k].ToString() == "." || lines[k].ToString() == "!" || lines[k].ToString() == "?")
                    {
                        CompletedString.Append("<br/>");
                    }
                }
            }
            ViewBag.CompletedString = CompletedString.ToString();
            return View("Index");
        }
    }
}
