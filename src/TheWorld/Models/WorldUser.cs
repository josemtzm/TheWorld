using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    // To allow identity, the class should implement some caracteristics
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}
