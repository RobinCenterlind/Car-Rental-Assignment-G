using Car_Rental.Common.Enumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public VehicleType Type { get; init; }

    public VehicleStatus Status { get; set; }

    public string Make { get; init; }

    public string RegNr { get; init; }
    public int Odometer { get; set; }

    public float CostKm { get; init; }

    public float CostDay { get; init; }

    public void Book();


}
