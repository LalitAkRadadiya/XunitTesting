using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Model;

namespace TEST.BAL.Interface
{
    public interface IPassengerManger
    {
        Passenger GetPassenger(int id);

        List<Passenger> GetAllPassenger();

        string CreatePassenger(Passenger model);

        string UpdatePassenger(Passenger model);

        string DeletePassenger(int id);
    }
}
