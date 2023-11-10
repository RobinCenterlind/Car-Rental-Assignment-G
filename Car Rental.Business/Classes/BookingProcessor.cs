using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using Car_Rental.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Common.Enumerals;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    IData Db { get; init; }

    private string preReturnedRegNr = "JKL012";
    private string preBookedRegNr = "GHI789";

    public BookingProcessor(IData db)
    {
        Db = db;
        foreach (Vehicle element in GetVehicles())
        {
            if (element.RegNr == preBookedRegNr)
                element.Rent();
        }
        foreach (IBooking element in GetBookings())
        {
            if (element.Vehicle.RegNr == preReturnedRegNr)
                element.CloseBooking(500);
        }
    }

    public List<IPerson> GetPersons()
    {
        return Db.Get<IPerson>(null);
    }
    public List<Vehicle> GetVehicles()
    {
        return Db.Get<Vehicle>(null);
    }
    public List<IBooking> GetBookings()
    {
        return Db.Get<IBooking>(null);
    }

    public IPerson? GetPerson(int id)
    {
        return Db.Single<IPerson>(b => b.Id == id);
    }
    
    public Vehicle? GetVehicle(int id)
    {
        return Db.Single<Vehicle>(b => b.Id == id);
        
    }

    public IBooking? GetBooking(int id)
    {
        return Db.Single<IBooking>(b => b.Vehicle.Id == id && b.Status == BookingStatus.Open);
    }
    public async Task RentVehicleAsync(int customerId, int vehicleId)
    {
        await Task.Delay(10000);
        Vehicle selectedVehicle = GetVehicle(vehicleId);
        selectedVehicle.Rent();
        Db.Add<IBooking>
            (
            new Booking(Db.NextBookingId, GetPerson(customerId), selectedVehicle)
            );

    }


    public void ReturnVehicle(int vehicleId, double distance)
    {
        if (distance < 0)
            throw new Exception();
        else
            GetBooking(vehicleId).CloseBooking(distance);
    }

    public void AddVehicle(string make, string regNr, double odometer, double costKm, VehicleType? type)
    {
        if (make.Length < 1 || regNr.Length < 1 || odometer < 0 || costKm < 0 || type is null)
            throw new Exception();

        else if (type == VehicleType.Motorcycle)
            Db.Add<Vehicle>
                (
                new Motorcycle(Db.NextVehicleId, make, regNr, odometer, costKm)
                );
        else
            Db.Add<Vehicle>
                (
                new Car(Db.NextVehicleId, type, make, regNr, odometer, costKm)
                );
    }

    public void AddCustomer(string firstName, string lastName, int socialSecurityNumber)
    {
        if (firstName.Length < 1 || lastName.Length < 1 || socialSecurityNumber < 0)
            throw new Exception();
        else
        {
            Db.Add<IPerson>
                (
                new Customer(Db.NextPersonId, firstName, lastName, socialSecurityNumber)
                );
        }
    }

    public string[] VehicleTypeNames => Db.VehicleTypeNames;

    public VehicleType? GetVehicleType(string name) => Db.GetVehicleType(name);



}
