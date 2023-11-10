using Car_Rental.Common.Enumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    abstract public class Vehicle
    {
        public int Id { get; init; }

        public VehicleType? Type { get; init; }

        public VehicleStatus Status { get; set; }

        public string Make { get; init; }

        public string RegNr { get; init; }
        public double Odometer { get; set; }

        public double CostKm { get; init; }

        public double CostDay { get; init; }

        public void Rent()
        {
            Status = VehicleStatus.Booked;
        }

        
    }
}
