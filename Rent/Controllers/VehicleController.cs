using Rent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rent.Controllers
{
    public class VehicleController : ApiController
    {
        private VehicleContext db = new VehicleContext();

        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await Task.Run(() => db.Vehicles.AsEnumerable<Vehicle>());
        }

        public async Task<Vehicle> Get(int id)
        {
            return await Task.Run(() => db.Vehicles.Find(id));
        }
    }
}
