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
            return _passengerManger.GetAllPassenger();
        }

        // GET: api/Passenger/5

        public IHttpActionResult Get(int id)
        {
            if (id != 0)
            {
                var pass = _passengerManger.GetPassenger(id);
                if (pass != null)
                {
                    return Ok(pass);

                }
                else
                {
                    return InternalServerError();
                }
            }
            return BadRequest("Invalid passenger id");

        }


        // POST: api/Passenger
        [HttpPost]
        public IHttpActionResult Post([FromBody] Passenger model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }
            else
            {
                return Ok(_passengerManger.CreatePassenger(model));
            }
        }

        // PUT: api/Passenger/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] Passenger model)
        {
            //var _passenger = _passengerManger.UpdatePassenger(model);
            //if (_passenger == null)
            //    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid model"));
            //else
            //    return Ok(_passenger);



            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }
            else
            {
                return Ok(_passengerManger.UpdatePassenger(model));
            }
        }

        // DELETE: api/Passenger/5
        public IHttpActionResult Delete(int id)
        {
            if (id != 0)
            {
                return BadRequest("Not a valid passenger id");
            }
            else
            {
                return Ok(_passengerManger.DeletePassenger(id));
            }
        }
    }
}
