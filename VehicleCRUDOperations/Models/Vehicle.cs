using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleCRUDOperations.Models
{
    public class Vehicle
    {
        public int id { get; set; }
        public string vrn { get; set; }
        public string vehicletypeid { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string fueltypeid { get; set; }
        public string enginesize { get; set; }
        public string statusid { get; set; }

    }
}