using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Model;

namespace TEST.DAL.Repository
{
    public interface IPassengerRepository
    {
        Passenger GetPassenger(int id);

        List<Passenger> GetAllPassenger();

        string CreatePassenger(Passenger model);

        string UpdatePassenger(Passenger model);

        string DeletePassenger(int id);


    }
}
