using Rent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rent.Controllers
{
    public class MakeController : ApiController
    {
        private VehicleContext db = new VehicleContext();

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Makes);
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Makes.Find(id).GetIDs().Select(mid => db.Models.Find(mid)));
        }

        [HttpPost]
        public HttpResponseMessage Post(Make make)
        {
            db.Makes.Add(make);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost]
        public HttpResponseMessage Post([FromUri] int id, Model model)
        {
            model.MakeID = id;
            db.Models.Add(model);
            db.SaveChanges();
            db.Makes.Find(id).AddID(model.ID);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /* http://localhost:30378/api/Make
         * 
         * User-Agent: Fiddler
         * content-type: application/json
         * Host: localhost:30378
         * Content-Length: 33
         * 
         * {"Name":"test","ModelIDs":"null"}
         */

    }
}