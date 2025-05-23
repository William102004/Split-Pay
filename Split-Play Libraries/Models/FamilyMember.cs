using System;
using System.Runtime.CompilerServices;

namespace Split_Pay_Libraries.Models;

public class FamilyMember
{
    public int id { get; set; }
    public string? Name { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    public double? balance  
    {
        get
        {
            return balance;
        }
        set
        {
            if (value != null)
            {
                balance = Math.Round((double)value, 2);
            }
            else
            {
                balance = 0.0;
            }
        }
    }

    public String? Display
    {
        get
        {
            return $"{id}.{Name}: ${balance}";
        }
    }

    public FamilyMember()
    {
        Name = string.Empty;
        email = string.Empty;
        phone = string.Empty;
        address = string.Empty;
        balance = 0.0;
    }
    public FamilyMember(int id ,string name, string Email, string Phone, string Address, double Balance)
    {
        Name = name;
        email = Email;
        phone = Phone;
        address = Address;
        balance = Balance;
    }
}
