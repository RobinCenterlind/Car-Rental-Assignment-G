using Car_Rental.Common.Enumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public IPerson Customer { get; init; }
    
    public IVehicle Vehicle { get; init; }

    public DateTime Rented { get; init; }

    public DateTime Returned { get; set; }

    public int KmRented { get; init; }

    public int KmUsed { get; init; }

    public double Cost { get; set; }

    public BookingStatus Status { get; set; }

    public void CloseBooking();
    




}
