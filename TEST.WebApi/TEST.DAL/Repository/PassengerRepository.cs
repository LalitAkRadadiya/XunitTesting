using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.DAL.Repository;
using TEST.Model;

namespace TEST.DAL
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly Database.AzureTestingDatabaseEntities _dbContext;

        public PassengerRepository()
        {
            _dbContext = new Database.AzureTestingDatabaseEntities();
        }

        public List<Passenger> GetAllPassenger()
        {
            var ent = _dbContext.TestDataTables.ToList();
            List<Passenger> list = new List<Passenger>();
            if(ent != null)
            {
                foreach (var item in ent) {
                    Passenger passenger = new Passenger();
                    passenger.Id = item.Id;
                    passenger.FirstName = item.FirstName;
                    passenger.LastName = item.LastName;
                    passenger.ContactNo = (int)item.ContactNo;


                    list.Add(passenger);
                } 
            }

            return list;
        }
        public string CreatePassenger(Passenger model)
        {
            try
            {
                if (model != null)
                {

                    Database.TestDataTable ent = new Database.TestDataTable();

                    ent.FirstName = model.FirstName;
                    ent.LastName = model.LastName;
                    ent.ContactNo = model.ContactNo;

                    _dbContext.TestDataTables.Add(ent);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "model is null";
            }
            catch (Exception)
            {
                return "model is null";
                
            }
        }

        public string DeletePassenger(int id)
        {
            try
            {
                var ent = _dbContext.TestDataTables.Find(id);

                if(ent!= null)
                {
                    _dbContext.TestDataTables.Remove(ent);
                    _dbContext.SaveChanges();
                    return "Delete Successfully";
                }
                return "Delete not working";

            }
            catch (Exception ex)
            {

                return "delete " + ex.Message;
            }
        }

       

 

        public string UpdatePassenger(Passenger model)
        {
            try
            {
                var ent = _dbContext.TestDataTables.Find(model.Id);
                if (ent != null)
                {


                    ent.FirstName = model.FirstName;
                    ent.LastName = model.LastName;
                    ent.ContactNo = model.ContactNo;

                    _dbContext.SaveChanges();

                    return "Successfully updated";
                }
                return "model is null";
            }
            catch (Exception ex)
            {

                return "model is null" + ex.Message;
            }
        }

        public Passenger GetPassenger(int id)
        {
            var ent = _dbContext.TestDataTables.Find(id);
            Passenger passenger = new Passenger();
            if(ent != null){
                passenger.Id = ent.Id;
                passenger.FirstName = ent.FirstName;
                passenger.LastName = ent.LastName;
                passenger.ContactNo = (int)ent.ContactNo;
            }

            return passenger;
        }
    }
}
