using Car_Rental.Common.Enumerals;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{

    public Car(int id, VehicleType? type, string make, string regNr, double odometer, double costKm, double costDay = 100)
    {
        Id = id;
        Status = VehicleStatus.Available;
        Type = type;
        Make = make;
        RegNr = regNr;
        Odometer = odometer;
        CostKm = costKm;
        CostDay = costDay;
    }

}
