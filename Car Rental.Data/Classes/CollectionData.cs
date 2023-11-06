using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Enumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    private List<IPerson> Persons { get; init; }
    private List<IVehicle> Vehicles { get; init; }
    private List<IBooking> Bookings { get; init; }

    public CollectionData()
    {
        Persons = new List<IPerson>()
        {
            new Customer("Chuck", "Bartowski", 12345),
            new Customer("Sarah", "Walker", 98765)
        };

        Vehicles = new List<IVehicle>()
        {
            new Car(VehicleType.Combi, "Volvo", "ABC123", 10000, 1, 200),
            new Car(VehicleType.Sedan, "Saab", "DEF456", 20000, 1, 100),
            new Car(VehicleType.Sedan, "Tesla", "GHI789", 1000, 3, 100),
            new Car(VehicleType.Van, "Jeep", "JKL012", 5000, 1.5f, 300),
            new Motorcycle("Yamaha", "MNO234", 30000, 0.5f, 50)
        };

        Bookings = new List<IBooking>()
        {
            new Booking(Persons[0], Vehicles[2]),
            new Booking(Persons[1], Vehicles[3])
        };
    }

    public List<IPerson> GetPersons()
    {
        return Persons;
    }
    public List<IVehicle> GetVehicles()
    {
        return Vehicles;
    }
    public List<IBooking> GetBookings()
    {
       return Bookings;
    }
}
