using SplitPayApp.ViewModels;

namespace SplitPayApp.Views;

public partial class HomeScreenView : TabbedPage
{
    public HomeScreenView()
    {
        InitializeComponent();

        // Subscribe to page changes
        this.CurrentPageChanged += OnCurrentPageChanged;
    }

    private void OnCurrentPageChanged(object? sender, EventArgs e)
{
        // Ensure the current page is not null before accessing its properties
        if (CurrentPage == null)
            return;
    // Refresh both views when switching tabs to ensure data is current
    if (CurrentPage?.Title == "Expenses")
    {
        if (CurrentPage is ContentPage contentPage && contentPage.Content is ExpenseView expenseView)
        {
            expenseView.RefreshView();
        }
    }
    
    if (CurrentPage?.Title == "Family Members")
    {
        if (CurrentPage is ContentPage familyContentPage && familyContentPage.Content is FamilyMembersView familyView)
        {
            if (familyView.BindingContext is FamilyMemberViewModel familyViewModel)
            {
                familyViewModel.refreshFamilyMembers();
            }
        }
    }
}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Unsubscribe to prevent memory leaks
        this.CurrentPageChanged -= OnCurrentPageChanged;
    }
 

}
