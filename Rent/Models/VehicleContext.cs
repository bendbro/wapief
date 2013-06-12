using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }

    public class Make
    {
        //data
        public int ID { get; set; }
        public string Name { get; set; }
        //links
        public string ModelIDs { get; set; }

        //for access to IDs
        public void AddID(int id)
        {
            ModelIDs = intstring.Add(ModelIDs, id);
        }
        public IEnumerable<int> GetIDs()
        {
            return intstring.Get(ModelIDs);
        }
    }

    public class Model
    {
        //data
        public int ID { get; set; }
        public string Name { get; set; }
        //links
        public int MakeID { get; set; }
        public string VehicleIDs { get; set; }

        //for access to IDs
        public void AddID(int id)
        {
            VehicleIDs = intstring.Add(VehicleIDs, id);
        }
        public IEnumerable<int> GetIDs()
        {
            return intstring.Get(VehicleIDs);
        }
    }

    public class Vehicle
    {
        //data
        public int ID { get; set; }
        public string Name { get; set; }
        //links
        public int ModelID { get; set; }
    }

    public class intstring
    {
        public static String Add(string IDs, int id)
        {
            if (IDs == null)
                IDs = "";

            return IDs + (char)((id >> 24) & 255) + (char)((id >> 16) & 255) + (char)((id >> 8) & 255) + (char)(id & 255);
        }

        public static IEnumerable<int> Get(string IDs)
        {
            if (IDs == null)
                IDs = "";

            List<int> ids = new List<int>();
            for (int index = 0; index < IDs.Length; index += 4)
            {
                ids.Add((((int)IDs[index]) << 24) + (((int)IDs[index+1]) << 16) + (((int)IDs[index+2]) << 8) + (((int)IDs[index+3])));
            }
            return ids;
        }
    }
}