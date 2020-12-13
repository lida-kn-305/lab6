using Lab6.App_Start;
using Lab6.Models;
using System;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class StadiumController : Controller
    {
        MyDbContext context = new MyDbContext();
        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Stadium c = new Stadium { id = id };
            context.Stadia.Attach(c);
            context.Stadia.Remove(c);
            context.SaveChanges();

            return RedirectToAction("Index", "Stadium");
        }

        [HttpGet]
        public ActionResult AddStadium()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStadium(Stadium stadium)
        {
            context.Stadia.Add(stadium);
            context.SaveChanges();

            return RedirectToAction("Index", "Stadium");
        }

        public ActionResult Update(FormCollection form)
        {
            var idString = Request.Form["id"];
            var name = Request.Form["name"];
            var square = Request.Form["square"];

            if (idString != null && name != null && square != null)
            {
                int id = int.Parse(idString);
                string newName = name.ToString();
                double newSquare = double.Parse(square);
                if (newName.Length != 0 && newSquare != 0)
                {
                    try
                    {
                        Update(id, newName, newSquare);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, name and square of stadium to update" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, name and square of stadium to update" });
            }
            return RedirectToAction("Index", "Stadium");
        }

        private void Update(int id, string name, double square)
        {
            var dbModel = context.Stadia.Find(id);
            if (dbModel != null)
            {
                dbModel.name = name;
                dbModel.square = square;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Stadium with id = " + id + " was not found!");
            }
        }
    }
}