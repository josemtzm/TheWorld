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

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("sam.hastings@theworld.com") == null)
            {
                // add the user
                var newUser = new WorldUser()
                {
                    UserName = "samhastings",
                    Email = "sam.hastings@theworld.com"
                };

                await _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }
            
            if(!_context.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "samhastings",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2014,6,4), Latitutde = 33.748995, Longitude=-84.387982, Order = 0 },
                        new Stop() { Name = "New york, NY", Arrival = new DateTime(2014,6,9), Latitutde = 40.712784, Longitude=-74.005941, Order = 1 },
                        new Stop() { Name = "Boston, MA", Arrival = new DateTime(2014,7,1), Latitutde = 42.360082, Longitude=-71.058880, Order = 2 },
                        new Stop() { Name = "Chicago, IL", Arrival = new DateTime(2014,7,10), Latitutde = 41.848114, Longitude=-87.629798, Order = 3 },
                        new Stop() { Name = "Seattle, WA", Arrival = new DateTime(2014,8,13), Latitutde = 47.606209, Longitude=-122.332071, Order = 4 },
                        new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2014,8,23), Latitutde = 33.748995, Longitude=84.387982, Order = 5 }
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    Name = "World Trip",
                    Created = DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2014,6,4), Latitutde = 33.748995, Longitude=-84.387982, Order = 0 },
                        new Stop() { Name = "New york, NY", Arrival = new DateTime(2014,6,9), Latitutde = 40.712784, Longitude=-74.005941, Order = 1 },
                        new Stop() { Name = "Boston, MA", Arrival = new DateTime(2014,7,1), Latitutde = 42.360082, Longitude=-71.058880, Order = 2 },
                        new Stop() { Name = "Chicago, IL", Arrival = new DateTime(2014,7,10), Latitutde = 41.848114, Longitude=-87.629798, Order = 3 },
                        new Stop() { Name = "Seattle, WA", Arrival = new DateTime(2014,8,13), Latitutde = 47.606209, Longitude=-122.332071, Order = 4 },
                        new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2014,8,23), Latitutde = 33.748995, Longitude=84.387982, Order = 5 }
                    }
                };

                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);

                _context.SaveChanges();
            }
        }
    }
}
