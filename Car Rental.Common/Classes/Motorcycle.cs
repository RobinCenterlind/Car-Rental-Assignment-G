using Car_Rental.Common.Enumerals;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public VehicleType Type { get; init; }

    public VehicleStatus Status { get; set; }

    public string Make { get; init; }

    public string RegNr { get; init; }
    public int Odometer { get; set; }

    public float CostKm { get; init; }

    public float CostDay { get; init; }

    public Motorcycle(string make, string regNr, int odometer, float costKm, float costDay)
    {
        Type = VehicleType.Motorcycle;
        Status = VehicleStatus.Available;
        Make = make;
        RegNr = regNr;
        Odometer = odometer;
        CostKm = costKm;
        CostDay = costDay;
    }

    public void Book()
    {
        Status = VehicleStatus.Booked;
    }
}
