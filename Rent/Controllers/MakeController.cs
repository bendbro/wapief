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
    public class MakeController : ApiController
    {
        private VehicleContext db = new VehicleContext();

        public async Task<HttpResponseMessage> Get()
        {
            return await Task.Run(async () =>
                Request.CreateResponse(HttpStatusCode.OK, 
                await Task.Run(() => db.Makes)));
        }

        public async Task<HttpResponseMessage> Get([FromUri] int id)
        {
            return await Task.Run(async () =>
                Request.CreateResponse(HttpStatusCode.OK, 
                await Task.Run(() => db.Makes.Find(id).GetIDs().Select(mid => db.Models.Find(mid)))));
        }

        public async Task<HttpResponseMessage> Post(Make make)
        {
            await Task.Run(() =>
            {
                db.Makes.Add(make);
                db.SaveChanges();
            });
            return await Task.Run(() => Request.CreateResponse(HttpStatusCode.OK));
        }
        
        public async Task<HttpResponseMessage> Post([FromUri] int id, Model model)
        {
            await Task.Run(() =>
            {
                model.MakeID = id;
                db.Models.Add(model);
                db.SaveChanges();
                db.Makes.Find(id).AddID(model.ID);
                db.SaveChanges();
            });
            return await Task.Run(() => Request.CreateResponse(HttpStatusCode.OK));
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