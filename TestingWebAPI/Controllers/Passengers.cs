using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingWebAPI.Repository.Interface;
using TestingWebAPI.Models;

namespace TestingWebAPI.Controllers
{
    public class Passengers : ApiController
    {
        private readonly IPassengerRepository _passengerRepository;

        public Passengers(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpGet]
        [Route("api/Passenger/Getpassengers")]
        public List<Passenger> GetPassengers()
        {
            return _passengerRepository.GetPassengers();
        }

        [HttpGet]
        [Route("api/Passenger/GetpassengerByid")]
        public HttpResponseMessage GetPassengerById(String id)
        {
            try
            {
                if (id != null)
                {
                    var passenger = _passengerRepository.GetPassengerById(id);
                    if (passenger.FirstName != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, passenger);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/Passenger/CreatePassenger")]
        public Passenger CreatePassenger(Passenger passenger)
        {
            return _passengerRepository.CreatePassenger(passenger);
        }

        [HttpPut]
        [Route("api/Passenger/Updatepassenger")]
        public Passenger UpdatePassenger(Passenger passenger)
        {
            return _passengerRepository.Update(passenger);
        }

        [HttpDelete]
        [Route("api/Passenger/Deletepassenger")]
        public bool DeletePassenger(String id)
        {
            return _passengerRepository.Delete(id);
        }
    }
}

