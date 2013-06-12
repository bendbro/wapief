using Rent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rent.Controllers
{
    public class ModelController : ApiController
    {
        private VehicleContext db = new VehicleContext();

        [Queryable]
        public IEnumerable<Model> Get()
        {
            return db.Models.AsEnumerable<Model>();
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri]int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Models.Find(id).GetIDs().Select(vid => db.Vehicles.Find(vid)));
        }

        [HttpPost]
        public HttpResponseMessage Post([FromUri]int id, Vehicle vehicle)
        {
            vehicle.ModelID = id;
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
            db.Models.Find(id).AddID(vehicle.ID);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
