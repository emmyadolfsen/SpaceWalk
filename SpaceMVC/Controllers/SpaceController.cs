using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpaceMVC.Models;


namespace SpaceMVC.Controllers
{
    public class SpaceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult SpaceWalk([FromQuery]string nameinput) // Skicka namn via url
        {
            // Lägg till namn i en sessionsvariabel
            HttpContext.Session.SetString("nameinput", nameinput); 
            ViewBag.input = nameinput;

            return View();
        }


        [HttpGet("/SpaceCat")]
        public IActionResult About()
        {
            // Hämta sessionsvariabel
            string output = HttpContext.Session.GetString("nameinput");

            // Kolla om sessionsvariabel finns
            if (output != null)
            {
                ViewBag.nameoutput = "Hej, " + output + ". ";
            }
            else
            {
                ViewBag.nameoutput = "Heeey, Stranger. ";
            }

            return View();
        }

        [HttpPost("/SpaceCat")] // Post för att hämtar formdata
        public IActionResult About(Item model)
        {
            if (ModelState.IsValid)
            {
                // Öppna jsonfil
                var JsonStr = System.IO.File.ReadAllText("items.json");
                var JsonObj = JsonConvert.DeserializeObject<List<Item>>(JsonStr); // Deserialisera till lista
                JsonObj.Add(model); // Lägg till input objektet
                // Lagra
                System.IO.File.WriteAllText("items.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));


                // Spara input i sessionsvariabler
                HttpContext.Session.SetString("objName", Request.Form["Name"]);
                HttpContext.Session.SetString("objMovie", Request.Form["Movie"]);
                HttpContext.Session.SetString("objDrink", Request.Form["Drink"]);
                HttpContext.Session.SetString("objAmCurl", Request.Form["AmericanCurl"]); // bool till sträng
                HttpContext.Session.SetString("objAmCream", Request.Form["AmericanCream"]); // bool till sträng
                HttpContext.Session.SetString("objBali", Request.Form["Balines"]); // bool till sträng

                return Redirect("~/Space/Hello"); // gör en redirect till hellosidan
            }
            return View();
        }


        [HttpGet]
        public IActionResult Hello()
        {
            // Hämta sessionsvariabler
            string objName = HttpContext.Session.GetString("objName");
            string objMovie = HttpContext.Session.GetString("objMovie");
            string objDrink = HttpContext.Session.GetString("objDrink");
            string objAmCurl = HttpContext.Session.GetString("objAmCurl");
            string objAmCream = HttpContext.Session.GetString("objAmCream");
            string objBali = HttpContext.Session.GetString("objBali");

            // Kolla om det blev rätt i miniquiz
            if ((objAmCurl == "true,false") && (objAmCream == "false") && (objBali == "true,false"))
            {

                ViewBag.result = "Bravo! =) Du hade helt rätt att American Curl och Balines är kattraser!";
                
            }
            else
            {
                ViewBag.result = "Du hade fel.. =( American Cream är en hästras.";
                    ViewBag.result2 = "American Curl och Balines är rätt svar.";
            }


            // Lägg input i viewbag för utskrift
            ViewBag.objName = objName;
            ViewBag.objMovie = objMovie;
            ViewBag.objDrink = objDrink;


            // Skapa ny instans av itemlist
            var itemlist = new List<Item>();

            // Läs in från json
            var JsonS = System.IO.File.ReadAllText("items.json");
            itemlist = JsonConvert.DeserializeObject<List<Item>>(JsonS);  // Deserialisera

            return View(itemlist); // Returnera listan till vy
        }

    }
}
