using Lab6.App_Start;
using Lab6.Models;
using System;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class GameController : Controller
    {
        MyDbContext context = new MyDbContext();
        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Game c = new Game { id = id };
            context.Games.Attach(c);
            context.Games.Remove(c);
            context.SaveChanges();

            return RedirectToAction("Index", "Game");
        }

        [HttpGet]
        public ActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGame(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();

            return RedirectToAction("Index", "Game");
        }

        public ActionResult Update(FormCollection form)
        {
            var idString = Request.Form["id"];
            var sportType = Request.Form["sportType"];
            var team1 = Request.Form["team1"];
            var team2 = Request.Form["team2"];

            if (idString != null && sportType != null && team1 != null && team2 != null)
            {
                int id = int.Parse(idString);
                string newSportType = sportType.ToString();
                string newTeam1 = team1.ToString();
                string newTeam2 = team2.ToString();
                if (newSportType.Length != 0 && newTeam1.Length != 0 && newTeam2.Length != 0)
                {
                    try
                    {
                        Update(id, newSportType, newTeam1, newTeam2);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, sport type and team names to update" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, sport type and team names to update" });
            }
            return RedirectToAction("Index", "Game");
        }

        private void Update(int id, string sportType, string newTeam1, string newTeam2)
        {
            var dbModel = context.Games.Find(id);
            if (dbModel != null)
            {
                dbModel.sportType = sportType;
                dbModel.team1 = newTeam1;
                dbModel.team2 = newTeam2;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Game with id = " + id + " was not found!");
            }
        }
    }
}