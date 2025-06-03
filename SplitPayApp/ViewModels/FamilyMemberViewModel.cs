using System;
using System.Collections.ObjectModel;
using Split_Pay_Libraries.Models;
using Split_Pay_Libraries.Services;
using Split_Play_Libraries.Services;

namespace SplitPayApp.ViewModels;

public class FamilyMemberViewModel : BaseViewModel
{

    private FamilyMember? CachedFamilyMember { get; set; }
    private HouseHoldService HouseHoldService = HouseHoldService.Current;

    public ObservableCollection<FamilyMember?> FamilyMembers
    {
        get
        {
            var FamilyMembers = HouseHoldService.Household;
            return new ObservableCollection<FamilyMember?>(FamilyMembers);
        }
    }
    public FamilyMember? FamilyMember { get; set; }

    public FamilyMember? SelectedFamilyMember { get; set; }
    public string? Name
    {
        get
        {
            return FamilyMember?.Name ?? string.Empty;
        }
        set
        {
            if (FamilyMember != null && FamilyMember.Name != value)
            {
                FamilyMember.Name = value;
            }
        }
    }
    public string? Email
    {
        get
        {
            return FamilyMember?.email ?? string.Empty;
        }
        set
        {
            if (FamilyMember != null && FamilyMember.email != value)
            {
                FamilyMember.email = value;
            }
        }
    }
    public string? Phone
    {
        get
        {
            return FamilyMember?.phone ?? string.Empty;
        }
        set
        {
            if (FamilyMember != null && FamilyMember.phone != value)
            {
                FamilyMember.phone = value;
            }
        }
    }
    public string? Address
    {
        get
        {
            return FamilyMember?.address ?? string.Empty;
        }
        set
        {
            if (FamilyMember != null && FamilyMember.address != value)
            {
                FamilyMember.address = value;
            }
        }
    }
    public double Balance
    {
        get
        {
            return FamilyMember?.Balance ?? 0.0;
        }
        set
        {
            if (FamilyMember != null && FamilyMember.Balance != value)
            {
                FamilyMember.Balance = value;
            }
        }
    }

    public void AddFamilyMember()
    {
        HouseHoldService.Current.AddFamilyMember(FamilyMember?.Name ?? string.Empty,
            FamilyMember?.email ?? string.Empty,
            FamilyMember?.phone ?? string.Empty,
            FamilyMember?.address ?? string.Empty,
            FamilyMember?.Balance ?? 0.0);
        refreshFamilyMembers();
      
    }
    public FamilyMember? RemoveFamilyMember()
    {
        var familyMember = HouseHoldService.RemoveFamilyMember(SelectedFamilyMember?.id ?? 0);
        refreshFamilyMembers();
        return familyMember;
    }

    public void UpdateMemberBalance(double newBalance)
    {
        HouseHoldService.Current.UpdateMemberBalance(SelectedFamilyMember?.id ?? 0, newBalance);
        if (SelectedFamilyMember != null)
        {
            SelectedFamilyMember.Balance = newBalance;
            NotifyPropertyChanged(nameof(SelectedFamilyMember));
        }
    }

    public FamilyMemberViewModel()
    {
        FamilyMember = new FamilyMember();
        CachedFamilyMember = null;
    }

    public FamilyMemberViewModel(FamilyMember familyMember)
    {
        FamilyMember = familyMember;
        if (familyMember != null)
        {
            CachedFamilyMember = new FamilyMember(familyMember.id, familyMember.Name, familyMember.email, familyMember.phone, familyMember.address, familyMember.Balance ?? 0.0);
        }
    }

    public void refreshFamilyMembers()
    {
        NotifyPropertyChanged(nameof(FamilyMembers));
    }
}
