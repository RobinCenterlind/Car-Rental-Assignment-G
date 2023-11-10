using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Enumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    private List<IPerson> _persons = new List<IPerson>();
    private List<Vehicle> _vehicles = new List<Vehicle>();
    private List<IBooking> _bookings = new List<IBooking>();

    public int NextPersonId  => _persons.Count.Equals(0) ? 1 : (_persons.Max(b => b.Id) + 1);
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : (_vehicles.Max(b => b.Id) + 1);
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : (_bookings.Max(b => b.Id) + 1);

    IQueryable<T> Reflect<T>()
    {
        var collectionType = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.FieldType == typeof(List<T>));

        var value = collectionType.GetValue(this);

        return ((List<T>)value).AsQueryable();
    }

    public List<T> Get<T>(Func<T, bool>? expression)
    {
        var collection = Reflect<T>();

        if (expression is null) return collection.ToList();

        return collection.Where(expression).ToList();

    }
    public T? Single<T>(Func<T, bool> expression)
    {
            var collection = Reflect<T>();

            return collection.SingleOrDefault(expression);
            
    }

    public void Add<T>(T item) 
    {
       if (item is IPerson)
           _persons.Add(item as IPerson);
       else if (item is Vehicle)
           _vehicles.Add(item as Vehicle);
       else
           _bookings.Add(item as IBooking);

        //Här under så kan du sätta en brytpunkt på debuggingmargin för att se hur denna reflection skapar en kopia av rätt lista
        //men när vi lägger till våran T item så läggs den endast till kopian och inte den riktiga listan.
        /*
        var collectionType = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.FieldType == typeof(List<T>));

        var value = collectionType.GetValue(this);

        var testing = ((List<T>)value).ToList();

        testing.Add(item);

        string debuggingmargin = "eroiw";

        debuggingmargin = "eirwo";*/


        


        //Reflect<T>().ToList().Add(item);

    }



    public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleType));

     public VehicleType? GetVehicleType(string name)
    {

        var test = Enum.GetValues(typeof(VehicleType));
       
        
        foreach(VehicleType element in test)
        {
            if (name == element.ToString())
                return element;     
        }
        return null;
        
        /*
        if (name == VehicleType.Motorcycle.ToString())
            return VehicleType.Motorcycle;
        else if (name == VehicleType.Combi.ToString())
            return VehicleType.Combi;
        else if (name == VehicleType.Van.ToString())
            return VehicleType.Van;
        else
            return VehicleType.Sedan;*/
        

        
        
    }

  

    public CollectionData()
    {

        _persons.Add(new Customer(NextPersonId, "Chuck", "Bartowski", 12345));
        _persons.Add(new Customer(NextPersonId, "Sarah", "Walker", 98765));



        _vehicles.Add(new Car(NextVehicleId, VehicleType.Combi, "Volvo", "ABC123", 10000, 1, 200));
        _vehicles.Add(new Car(NextVehicleId, VehicleType.Sedan, "Saab", "DEF456", 20000, 1, 100));
        _vehicles.Add(new Car(NextVehicleId, VehicleType.Sedan, "Tesla", "GHI789", 1000, 3, 100));
        _vehicles.Add(new Car(NextVehicleId, VehicleType.Van, "Jeep", "JKL012", 5000, 1.5f, 300));
        _vehicles.Add(new Motorcycle(NextVehicleId, "Yamaha", "MNO234", 30000, 0.5f, 50));



        _bookings.Add(new Booking(NextBookingId, _persons[0], _vehicles[2]));
        _bookings.Add(new Booking(NextBookingId, _persons[1], _vehicles[3]));
        
    }

    
}
