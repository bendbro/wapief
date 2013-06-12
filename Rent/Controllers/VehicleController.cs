using Rent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rent.Controllers
{
    public class VehicleController : ApiController
    {
        private VehicleContext db = new VehicleContext();

        [Queryable]
        public IEnumerable<Vehicle> Get()
        {
            return db.Vehicles.AsEnumerable<Vehicle>();
        }

        [HttpGet]
        public Vehicle Get(int vehicleID)
        {
            return db.Vehicles.Find(vehicleID);
        }
    }
}
