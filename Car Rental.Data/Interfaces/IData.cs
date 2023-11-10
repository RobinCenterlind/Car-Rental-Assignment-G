using Car_Rental.Common.Classes;
using Car_Rental.Common.Enumerals;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    public List<T> Get<T>(Func<T, bool>? expression);

    public T? Single<T>(Func<T, bool> expression);

    public void Add<T>(T item);

    public string[] VehicleTypeNames { get; }

    public VehicleType? GetVehicleType(string name);

    public int NextVehicleId { get; }
    public int NextPersonId { get; }
    public int NextBookingId { get; }
   

}
