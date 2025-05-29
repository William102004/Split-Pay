using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Split_Pay_Libraries.Models;
using Split_Play_Libraries.Models;

namespace Split_Pay_Libraries.Services;

public class HouseHoldService
{
    public double HouseholdBalance = 0.0;
    public string? HouseHoldName { get; set; }
    
    private HouseHoldService()
    {
        Household = new List<FamilyMember?>();
    }

    private int LastKey
    {
        get
        {
            if (!Household.Any())
            {
                return 0;
            }

            return Household.Select(f => f?.id ?? 0).Max();
        }
    }
    
    private static HouseHoldService? instance;
    private static object instanceLock = new object();
    
    public static HouseHoldService Current
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new HouseHoldService();
                }
            }

            return instance;
        }
    }

    public List<FamilyMember?> Household { get; private set; }

    // Fixed: Now properly generates ID and initializes expenses list
    public FamilyMember AddFamilyMember(string Name, string Email, string Phone, string Address, double Balance)
    {
        int newId = LastKey + 1;
        FamilyMember familyMember = new FamilyMember(newId, Name, Email, Phone, Address, Balance);
        
        // Initialize the expenses list
        familyMember.expenses = new List<Expense?>();
        
        Household.Add(familyMember);
        HouseholdBalance = Math.Round(HouseholdBalance + Balance, 2);
        
        return familyMember;
    }
    
    public FamilyMember? GetFamilyMember(int id)
    {
        return Household.FirstOrDefault(f => f?.id == id);
    }

    public List<FamilyMember?> GetHouseHoldMembers()
    {
        return Household.Where(m => m != null).ToList();
    }

    public bool RemoveFamilyMember(int id)
    {
        FamilyMember? familyMember = Household.FirstOrDefault(f => f?.id == id);
        if (familyMember != null)
        {
            HouseholdBalance = Math.Round(HouseholdBalance - (familyMember.Balance ?? 0.0), 2);
            return Household.Remove(familyMember);
        }

        return false;
    }

    // Fixed: Corrected balance calculation logic
    public void UpdateMemberBalance(int id, double newBalance)
    {
        var familyMember = GetFamilyMember(id);
        if (familyMember != null)
        {
            // Remove old balance from household total
            HouseholdBalance = Math.Round(HouseholdBalance - (familyMember.Balance ?? 0.0), 2);
            
            // Set new balance
            familyMember.Balance = newBalance;
            
            // Add new balance to household total
            HouseholdBalance = Math.Round(HouseholdBalance + newBalance, 2);
        }
    }
    
    public double GetHouseholdBalance()
    {
        return HouseholdBalance;
    }
    
    public void DeleteHousehold()
    {
        Household.Clear();
        HouseholdBalance = 0.0;
    }
}