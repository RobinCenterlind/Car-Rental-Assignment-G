using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public string FirstName { get; init ; }
    public string LastName { get ; init ; }
    public int SocialSecurityNumber { get; init; }

    public Customer(string firstName, string lastName, int socialSecurityNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;
    }
}
