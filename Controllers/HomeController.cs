using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading;
// using Word = Microsoft.Office.Interop.Word;


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
            FontList.Add("Calibri");
            FontList.Add("Comic Sans");
            FontList.Add("Ink Free");
            FontList.Add("Segoe Print");
            FontList.Add("Courier");
            // FontList.Add("Shadows Into Light, cursive");
            // FontList.Add("Shadows Into Light Two, cursive");
            // FontList.Add("Give You Glory, cursive");
            // FontList.Add("The Girl Next Door, cursive");

            // This loop performs the actual creation of the string depending on the num of lines the user set.
            // It chooses a random font based on the prepolulated list.
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


            // This code takes the CompletedString and puts it into a new Word document. However, it does not parse the HTML and CSS to formattd .docx text. Need to do some more digging to understand how.

            // object oMissing = System.Reflection.Missing.Value;
            // object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            
            // //Start Word and create a new document.
            // Word._Application oWord;
            // Word._Document oDoc;
            // oWord = new Word.Application();
            // oWord.Visible = true;
            // oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            
            // //Insert a paragraph at the beginning of the document.
            // Word.Paragraph oPara1;
            // oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            // oPara1.Range.Text = CompletedString.ToString();
            // // oPara1.Range.Font.Bold = 1;
            // oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
            // oPara1.Range.InsertParagraphAfter();

            return View("Index");
        }
    }
}
