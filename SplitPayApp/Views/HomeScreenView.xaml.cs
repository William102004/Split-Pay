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
        // Refresh expense view when expenses tab is selected
        if (CurrentPage?.Title == "Expenses")
        {
            // Find the ExpenseView in the current page's content
            if (CurrentPage is ContentPage contentPage && contentPage.Content is ExpenseView expenseView)
            {
                expenseView.RefreshView();
            }
        }
        
        // Refresh family members view when family members tab is selected
        if (CurrentPage?.Title == "Family Members")
        {
            // Find the FamilyMembersView and refresh it
            if (CurrentPage is ContentPage familyContentPage && familyContentPage.Content is FamilyMembersView familyView)
            {
                // You can add a similar refresh method to FamilyMembersView if needed
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
