using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using Car_Rental.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    IData Db { get; init; }

    private string returnedRegNr = "JKL012";
    private string bookedRegNr = "GHI789";

    public BookingProcessor(IData db) => Db = db;

    public List<IPerson> GetPersons()
    {
        return Db.GetPersons();
    }
    public List<IVehicle> GetVehicles()
    {
        List<IVehicle> updatedList = Db.GetVehicles();
        foreach (IVehicle element in updatedList)
        {
            if (element.RegNr == bookedRegNr)
                element.Book();
        }
        return updatedList;
            
    }
    public List<IBooking> GetBookings()
    {
        List<IBooking> updatedList = Db.GetBookings();

        foreach(IBooking element in updatedList)
        {
            if (element.Vehicle.RegNr == returnedRegNr)
                element.CloseBooking();
        }
        return updatedList;
    }
}
