using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Split_Pay_Libraries.Models;
using Split_Pay_Libraries.Services;
using Split_Play_Libraries.Services;

namespace SplitPayApp.ViewModels;

public class FamilyMemberViewModel : BaseViewModel
{

    public ICommand? RemoveCommand { get; set; }
    public void DoDelete()
    {
        HouseHoldService.Current.RemoveFamilyMember(FamilyMember?.id ?? 0);
    }
    void SetupCommands()
    {
        RemoveCommand = new Command(DoDelete);
    }
    private FamilyMember? _familyMember;
    private FamilyMember? _selectedFamilyMember;
    private HouseHoldService HouseHoldService = HouseHoldService.Current;

    public double newBalance { get; set; }

    public ObservableCollection<FamilyMember?> FamilyMembers
    {
        get
        {
            var familyMembers = HouseHoldService.Household.Where(m => m != null).ToList();
            return new ObservableCollection<FamilyMember?>(familyMembers);
        }
    }

    public FamilyMember? FamilyMember 
    { 
        get => _familyMember;
        set
        {
            _familyMember = value;
            NotifyPropertyChanged();
            // Notify all related properties
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Email));
            NotifyPropertyChanged(nameof(Phone));
            NotifyPropertyChanged(nameof(Address));
            NotifyPropertyChanged(nameof(Balance));
        }
    }

    public FamilyMember? SelectedFamilyMember 
    { 
        get => _selectedFamilyMember;
        set
        {
            _selectedFamilyMember = value;
            NotifyPropertyChanged();
        }
    }

    public double HouseholdBalance => HouseHoldService.Current.HouseholdBalance;

    public string? Name
    {
        get => FamilyMember?.Name ?? string.Empty;
        set
        {
            if (FamilyMember != null && FamilyMember.Name != value)
            {
                FamilyMember.Name = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string? Email
    {
        get => FamilyMember?.email ?? string.Empty;
        set
        {
            if (FamilyMember != null && FamilyMember.email != value)
            {
                FamilyMember.email = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string? Phone
    {
        get => FamilyMember?.phone ?? string.Empty;
        set
        {
            if (FamilyMember != null && FamilyMember.phone != value)
            {
                FamilyMember.phone = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string? Address
    {
        get => FamilyMember?.address ?? string.Empty;
        set
        {
            if (FamilyMember != null && FamilyMember.address != value)
            {
                FamilyMember.address = value;
                NotifyPropertyChanged();
            }
        }
    }

    public double Balance
    {
        get => FamilyMember?.Balance ?? 0.0;
        set
        {
            if (FamilyMember != null && FamilyMember.Balance != value)
            {
                FamilyMember.Balance = value;
                NotifyPropertyChanged();
            }
        }
    }

    public void AddFamilyMember()
    {
        if (FamilyMember != null && !string.IsNullOrWhiteSpace(FamilyMember.Name))
        {
            HouseHoldService.Current.AddFamilyMember(
                FamilyMember.Name ?? string.Empty,
                FamilyMember.email ?? string.Empty,
                FamilyMember.phone ?? string.Empty,
                FamilyMember.address ?? string.Empty,
                FamilyMember.Balance ?? 0.0);

            // Clear the form by creating a new FamilyMember instance
            FamilyMember = new FamilyMember();
            refreshFamilyMembers();
        }
    }

    public FamilyMember? RemoveFamilyMember()
    {
        if (SelectedFamilyMember != null)
        {
            var familyMember = HouseHoldService.RemoveFamilyMember(SelectedFamilyMember.id);
            refreshFamilyMembers();
            return familyMember;
        }
        return null;
    }

    public void UpdateMemberBalance()
    {
        if (SelectedFamilyMember != null)
        {
            HouseHoldService.Current.UpdateMemberBalance(SelectedFamilyMember.id, newBalance);
            SelectedFamilyMember.Balance = newBalance;
            refreshFamilyMembers();
        }
    }

    public FamilyMemberViewModel()
    {
        FamilyMember = new FamilyMember();
        SetupCommands();
    }

    public void refreshFamilyMembers()
    {
        NotifyPropertyChanged(nameof(FamilyMembers));
        NotifyPropertyChanged(nameof(HouseholdBalance));
        NotifyPropertyChanged(nameof(SelectedFamilyMember));
        NotifyPropertyChanged(nameof(newBalance));
       
    }
}