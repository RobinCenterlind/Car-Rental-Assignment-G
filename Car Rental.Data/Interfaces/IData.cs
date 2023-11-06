using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    List<IPerson> GetPersons();
    List<IVehicle> GetVehicles();
    List<IBooking> GetBookings();

}
