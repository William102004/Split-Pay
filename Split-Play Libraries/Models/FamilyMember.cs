
using System;
using System.Runtime.CompilerServices;
using Split_Play_Libraries.Models;

namespace Split_Pay_Libraries.Models;

public class FamilyMember
{
    public int id { get; set; }
    public List<Expense?> expenses { get; set; }
    public string? Name { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    private double? balance;
    
    public double? Balance
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
        expenses = new List<Expense?>(); // Initialize expenses list
    }
    
    public FamilyMember(int id, string name, string Email, string Phone, string Address, double? Balance)
    {
        this.id = id; // Set the ID properly
        Name = name;
        email = Email;
        phone = Phone;
        address = Address;
        balance = Balance;
        expenses = new List<Expense?>(); // Initialize expenses list
    }
}