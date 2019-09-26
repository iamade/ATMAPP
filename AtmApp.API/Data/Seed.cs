using System.Collections.Generic;
using System.Linq;
using AtmApp.API.Models;
using Newtonsoft.Json;

namespace AtmApp.API.Data
{
    public class Seed
    {
        public static void SeedAtmsFleet(DataContext context)
        {
            if (!context.AtmFleet.Any())
            {
                var atmFleetData = System.IO.File.ReadAllText("Data/AtmFleetSeedData.json");
                var atmFleets = JsonConvert.DeserializeObject<List<AtmFleet>>(atmFleetData);

                foreach (var atm in atmFleets )
                {
                    context.AtmFleet.Add(atm);
                }
                context.SaveChanges();
            }
        }
    }
}