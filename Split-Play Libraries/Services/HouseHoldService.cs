using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Split_Pay_Libraries.Models;

namespace Split_Pay_Libraries.Services;

public class HouseHoldService
{
     double HouseholdBalance = 0.0;
    string? HouseHoldName { get; set; }
  

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


    public void AddFamilyMember(string Name, string Email, string Phone, string Address, double Balance)
    {
        int newId = LastKey + 1;
        FamilyMember familyMember = new FamilyMember(newId, Name, Email, Phone, Address, Balance);
        Household.Add(familyMember);
        HouseholdBalance = Math.Round(HouseholdBalance + Balance, 2);

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
        FamilyMember? familyMember = GetFamilyMember(id);
        if (familyMember != null)
        {
            HouseholdBalance = Math.Round(HouseholdBalance - familyMember.balance ?? 0.0, 2);
            return Household.Remove(familyMember);
        }

        return false;
    }

    public void UpdateMemberBalance(int id, double newBalance)
    {
        FamilyMember? familyMember = GetFamilyMember(id);
        if (familyMember != null)
        {
            HouseholdBalance = Math.Round(HouseholdBalance - familyMember.balance ?? 0.0 + newBalance, 2);
            familyMember.balance = newBalance;
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
