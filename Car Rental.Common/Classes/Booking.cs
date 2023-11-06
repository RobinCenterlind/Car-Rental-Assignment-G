using Car_Rental.Common.Enumerals;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public IPerson Customer { get; init; }

    public IVehicle Vehicle { get; init; }

    public DateTime Rented { get; init; }

    public DateTime Returned { get; set; }

    public int KmRented { get; init; }

    public int KmUsed { get; init; } = 0;

    public double Cost { get; set; }

    public BookingStatus Status { get; set ; }

    public Booking(IPerson customer, IVehicle vehicle)
    {
        Customer = customer;
        Vehicle = vehicle;
        Rented = DateTime.Now;
        KmRented = vehicle.Odometer;
        Status = BookingStatus.Open;
    }

    public void CloseBooking()
    {
        Status = BookingStatus.Closed;
        Returned = DateTime.Now;
        if ((Returned - Rented).TotalDays > 1)
            Cost = Vehicle.CostDay * (Returned - Rented).TotalDays + Vehicle.CostKm * KmUsed;
        else
            Cost = Vehicle.CostDay * 1 + Vehicle.CostKm * KmUsed;
        Vehicle.Odometer = KmRented + KmUsed;
        Vehicle.Status = VehicleStatus.Available;

    }
}
