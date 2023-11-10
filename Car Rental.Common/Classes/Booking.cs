using Car_Rental.Common.Enumerals;
using Car_Rental.Common.Extensions;
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
    public int Id { get; init; }
    public IPerson Customer { get; init; }

    public Vehicle Vehicle { get; init; }

    public DateTime Rented { get; init; }

    public DateTime Returned { get; set; }

    public double KmRented { get; init; }

    public double KmReturned { get; set; } = 0;

    public double Cost { get; set; }

    public BookingStatus Status { get; set ; }

    public Booking(int id, IPerson customer, Vehicle vehicle)
    {
        Id = id;
        Customer = customer;
        Vehicle = vehicle;
        Rented = DateTime.Now;
        KmRented = vehicle.Odometer;
        Status = BookingStatus.Open;
    }

    public void CloseBooking(double distance)
    {
        KmReturned = KmRented + distance;
        Vehicle.Odometer = KmReturned;
        Status = BookingStatus.Closed;
        Returned = DateTime.Now;
        if (Rented.Duration(Returned) > 1)
            Cost = Vehicle.CostDay * Rented.Duration(Returned) + Vehicle.CostKm * distance;
        else
            Cost = Vehicle.CostDay * 1 + Vehicle.CostKm * distance;
        Vehicle.Status = VehicleStatus.Available;

    }

}
