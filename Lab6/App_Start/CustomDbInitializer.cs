using Lab6.App_Start;
using System.Data.Entity;


namespace Lab6.App_Start
{
    public class CustomDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {

        protected override void Seed(MyDbContext context)
        {
            context.Countries.Add(new Lab6.Models.Country { name = "Ukraine", capitalCity = "Kyiv" });
            context.Countries.Add(new Lab6.Models.Country { name = "Great Britain", capitalCity = "London" });
            context.Countries.Add(new Lab6.Models.Country { name = "Canada", capitalCity = "Ottawa" });
            context.Countries.Add(new Lab6.Models.Country { name = "Austria", capitalCity = "Vena" });

            context.Games.Add(new Lab6.Models.Game { sportType = "baseball", team1 = "White Sox", team2 = "Shahtar" });
            context.Games.Add(new Lab6.Models.Game { sportType = "baseball", team1 = "Astros", team2 = "Shahtar" });
            context.Games.Add(new Lab6.Models.Game { sportType = "football", team1 = "Mets", team2 = "Dynamo" });
            context.Games.Add(new Lab6.Models.Game { sportType = "football", team1 = "Black Fox", team2 = "Vorskla" });

            context.Stadia.Add(new Lab6.Models.Stadium { name = "Stadium#1", square = 90.0, countryId = 1 });
            context.Stadia.Add(new Lab6.Models.Stadium { name = "Stadium#2", square = 90.0, countryId = 1 });
            context.Stadia.Add(new Lab6.Models.Stadium { name = "Stadium#3", square = 90.0, countryId = 1 });
            context.Stadia.Add(new Lab6.Models.Stadium { name = "Stadium#4", square = 90.0, countryId = 1 });

            context.Schedules.Add(new Lab6.Models.Schedule { countryId = 1, gameId = 2 });
            context.Schedules.Add(new Lab6.Models.Schedule { countryId = 2, gameId = 3 });
            context.Schedules.Add(new Lab6.Models.Schedule { countryId = 3, gameId = 4 });
            context.Schedules.Add(new Lab6.Models.Schedule { countryId = 4, gameId = 1 });
        }

    }
}