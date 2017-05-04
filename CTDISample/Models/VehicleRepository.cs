using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTDISample.Models
{
    public interface IVehicleRepository
    {
        IEnumerable<VEHICLE> GetAll();
        VEHICLE Get(int id);
        VEHICLE Add(VEHICLE item);
        void Remove(int id);
        bool Update(VEHICLE item);

        
    }

    public class VehicleRepository : IVehicleRepository
    {

        private readonly CTDIContext _db;

        public VehicleRepository()
        {
            _db = new CTDIContext();
        }

        public IEnumerable<VEHICLE> GetAll()
        {
            return _db.Vehicles;
        }

        public VEHICLE Get(int id)
        {
            return _db.Vehicles.Find(id);
        }

        public VEHICLE Add(VEHICLE vhl)
        {
            _db.Vehicles.Add(vhl);
            _db.SaveChanges();
            return vhl;
        }

        public void Remove(int id)
        {
            VEHICLE vhl = _db.Vehicles.Find(id);
            _db.Vehicles.Remove(vhl);
            _db.SaveChanges();
        }

        public bool Update(VEHICLE item)
        {
            VEHICLE vhl =_db.Vehicles.Find(item.VEHICLE_ID);
            if (vhl == null)
                return false;

            vhl.VEHICLE_MODEL = item.VEHICLE_MODEL;
            vhl.VEHICLE_OWNER = item.VEHICLE_OWNER;
            vhl.VEHICLE_NUMBER = item.VEHICLE_NUMBER;

            _db.SaveChanges();
            return true;
        }
    }
}