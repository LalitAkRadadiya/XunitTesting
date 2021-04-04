using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST.BAL;
using TEST.BAL.Interface;
using TEST.Model;

namespace TEST.WebApi.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IPassengerManger _passengerManger;
        
        
        public PassengerController(IPassengerManger passengerManger)
        {
            _passengerManger = passengerManger;
        }


        // GET: api/Passenger
        public List<Passenger> Get()
        {

            //PassengerManger passengerManger = new PassengerManger();
            //passengerManger.GetPassenger();
            //var passenger = _passengerManger.GetAllPassenger();
            return _passengerManger.GetAllPassenger();
//;            return new string[] { "value1", "value2" };
        }

        // GET: api/Passenger/5

        public Passenger Get(int id)
        {
            return _passengerManger.GetPassenger(id);
        }

        // POST: api/Passenger
        [HttpPost]
        public string Post([FromBody]Passenger model)
        {
            return _passengerManger.CreatePassenger(model);
        }

        // PUT: api/Passenger/5
        [HttpPut]
        public string Put([FromBody]Passenger model)
        {
            return _passengerManger.UpdatePassenger(model);
        }

        // DELETE: api/Passenger/5
        public string Delete(int id)
        {
            return _passengerManger.DeletePassenger(id);
        }
    }
}
