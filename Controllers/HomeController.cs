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
        public IActionResult SubmitLines(string lines, int numLines,)
        {
            // Function scope variable declarations
            List<string> FontList = new List<string>();
            StringBuilder CompletedString = new StringBuilder();
            int RandomFont = 0;
            Random rand = new Random();

            // Add various fonts into FontList (imported on the _Layout.cshtml page)
            FontList.Add("Shadows Into Light, cursive");
            FontList.Add("Shadows Into Light Two, cursive");
            FontList.Add("Give You Glory, cursive");
            FontList.Add("The Girl Next Door, cursive");


            for (int j = 0; j < numLines; j++)
            {
                for (var k = 0; k < lines.Length; k++)
                {
                    CompletedString.Append("<span>" + lines[k] + "</span>");
                    if (lines[k].ToString() == "." || lines[k].ToString() == "!" || lines[k].ToString() == "?")
                    {
                        CompletedString.Append("<br/>");
                    }
                }
            }
                
                for (var i = 0; i < CompletedString.Length - 5; i++)
                {
                    // Choose random font from the list.
                    RandomFont = rand.Next(0, 4);
                    if (CompletedString[i] + "" + CompletedString[i + 1] + "" + CompletedString[i + 2] + "" + CompletedString[i + 3] + "" + CompletedString[i + 4] + "" + CompletedString[i + 5] == "<span>")
                    {
                        CompletedString.Insert(i + 5, $" style=\"font-family:{FontList[RandomFont]}\"");
                    }

                    // If one line has been written already, rerandomize the font selection so that the letters are not uniform.
                    // if(CompletedString[i] + "" + CompletedString[i + 1] + "" + CompletedString[i + 2] + "" + CompletedString[i + 3] + "" + CompletedString[i + 4] == "<br/>")
                    // {
                    //     Thread.Sleep(2000);

                    // }
                }
            ViewBag.CompletedString = CompletedString.ToString();
            return View("Index");
        }
    }
}
