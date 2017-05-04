using CTDISample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CTDISample.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly IVehicleRepository _vehicles = new VehicleRepository();

        // GET api/values
        public IEnumerable<VEHICLE> Get()
        {
            return _vehicles.GetAll();
        }

        // GET api/values/5
        public VEHICLE Get(int id)
        {
            VEHICLE vhl = _vehicles.Get(id);
            if (vhl == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return vhl;
        }

        // POST api/values
        public VEHICLE Post(VEHICLE vhl)
        {
            return _vehicles.Add(vhl);
        }

        // PUT api/values/5
        public VEHICLE Put(VEHICLE vhl)
        {
            if (!_vehicles.Update(vhl))
            throw new HttpResponseException(HttpStatusCode.NotFound);

            return vhl;
        }

        // DELETE api/values/5
        public VEHICLE Delete(int id)
        {
            VEHICLE c = _vehicles.Get(id);
            _vehicles.Remove(id);
            return c;
        }
    }
}