using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context,UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("alper.dortbudak@gmail.com") == null)
            {
                var newUser = new WorldUser()
                {
                    UserName = "adortbudak",
                    Email = "alper.dortbudak@gmail.com"
                };

               await _userManager.CreateAsync(newUser,"P@ssword!");
            }



            if (!_context.Trips.Any())
            {
                //Add new data
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "adortbudak",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name="Seattle, GA", Arrival = DateTime.UtcNow,Latitude = 0, Longitude=0,Order=0},
                        new Stop() { Name="Chicago, IL", Arrival = DateTime.UtcNow,Latitude = 0, Longitude=0,Order=1},
                        new Stop() { Name="Milwaukee, WI", Arrival = DateTime.UtcNow,Latitude = 0, Longitude=0,Order=2}
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    Name = "World Trip",
                    Created = DateTime.UtcNow,
                    UserName = "adortbudak",
                    Stops = new List<Stop>()
                    {
                       new Stop() { Name="Seattle, GA", Arrival = DateTime.UtcNow,Latitude = 0, Longitude=0,Order=0},
                        new Stop() { Name="Chicago, IL", Arrival = DateTime.UtcNow,Latitude = 0, Longitude=0,Order=1},
                        new Stop() { Name="Milwaukee, WI", Arrival = DateTime.UtcNow,Latitude = 0, Longitude=0,Order=2}
                    }
                };

                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);

                _context.SaveChanges();
            }
        }
    }
}
