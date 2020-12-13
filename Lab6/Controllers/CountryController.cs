using Lab6.App_Start;
using Lab6.Models;
using System;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class CountryController : Controller
    {
        MyDbContext context = new MyDbContext();
        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Country c = new Country { id = id };
            context.Countries.Attach(c);
            context.Countries.Remove(c);
            context.SaveChanges();

            return RedirectToAction("Index", "Country");
        }

        [HttpGet]
        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();

            return RedirectToAction("Index", "Country");
        }

        public ActionResult Update(FormCollection form)
        {
            var idString = Request.Form["id"];
            var countryName = Request.Form["name"];
            var capitalCity = Request.Form["capitalCity"];

            if (idString != null && countryName != null && capitalCity != null)
            {
                int id = int.Parse(idString);
                string newName = countryName.ToString();
                string newCapitalCity = capitalCity.ToString();
                if (newName.Length != 0 && newCapitalCity.Length != 0)
                {
                    try
                    {
                        Update(id, newName, newCapitalCity);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, the name and the capital city of the country to update" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, the name and the capital city of the country to update" });
            }
            return RedirectToAction("Index", "Country");
        }

        private void Update(int id, string name, string capitalCity)
        {
            var dbModel = context.Countries.Find(id);
            if (dbModel != null)
            {
                dbModel.name = name;
                dbModel.capitalCity = capitalCity;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Country with id = " + id + " was not found!");
            }
        }
    }
}