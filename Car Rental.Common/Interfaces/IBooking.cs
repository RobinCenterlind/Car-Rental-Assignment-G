using Car_Rental.Common.Classes;
using Car_Rental.Common.Enumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public int Id { get; init; }
    public IPerson Customer { get; init; }
    
    public Vehicle Vehicle { get; init; }

    public DateTime Rented { get; init; }

    public DateTime Returned { get; set; }

    public double KmRented { get; init; }

    public double KmReturned { get; set; }

    public double Cost { get; set; }

    public BookingStatus Status { get; set; }

    public void CloseBooking(double distance);

   
    




}
