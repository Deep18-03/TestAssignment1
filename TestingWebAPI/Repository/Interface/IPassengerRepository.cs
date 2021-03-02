using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingWebAPI.Models;

namespace TestingWebAPI.Repository.Interface
{
    public interface IPassengerRepository
    {
        Passenger CreatePassenger(Passenger passenger);
        List<Passenger> GetPassengers();
        Passenger GetPassengerById(string id);
        Passenger Update(Passenger passenger);
        bool Delete(string id);
       


    }
}