using System;
using TEST.BAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Model;
using TEST.DAL.Repository;

namespace TEST.BAL
{
    public class PassengerManger : IPassengerManger
    {
        private readonly IPassengerRepository _passengerRepository;
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        public PassengerManger(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public string CreatePassenger(Passenger model)
        {
            return _passengerRepository.CreatePassenger(model);
        }

        public string DeletePassenger(int id)
        {
            return _passengerRepository.DeletePassenger(id);
        }

        public List<Passenger> GetAllPassenger()
        {
            return _passengerRepository.GetAllPassenger();
        }

        public Passenger GetPassenger(int id)
        {
            return _passengerRepository.GetPassenger(id);
        }

        public string UpdatePassenger(Passenger model)
        {
            return _passengerRepository.UpdatePassenger(model);
        }
    }
}
