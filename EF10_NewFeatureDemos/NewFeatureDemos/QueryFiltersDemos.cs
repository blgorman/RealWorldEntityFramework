
using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class QueryFiltersDemos : IAsyncDemo
{
    private InventoryDbContext _db;

    public QueryFiltersDemos(InventoryDbContext context)
    {
        _db = context;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Original Query Operation",
            "Query with Named Filters",
            "Exit"
        };
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {

        switch (choice)
        {
            case 1:
                await ShowNonNamedQueryFilters();
                break;
            case 2:
                await ShowNamedQueryFilters();
                break;
            case 3:
                return false;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
        return true;
    }

    public async Task RunAsync()
    {
        bool shouldContinue = true;
        while (shouldContinue)
        {
            Console.Clear();

            List<string> menuOptions = GetMenuOptions();

            var menuText = MenuGenerator.GenerateMenu("Query Filters Demos", "Please select an operation", menuOptions, 40);

            // Show menu and get user choice
            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            try
            {
                shouldContinue = await HandleMenuChoiceAsync(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private async Task ShowNonNamedQueryFilters()
    {
        Console.WriteLine("Contributors With Query Filters Demo Started");

        Console.WriteLine("Contributors With Query Filters Completed");

        UserInput.WaitForUserInput();
    }

    private async Task ShowNamedQueryFilters()
    {
        Console.WriteLine("Categories with Named Query Filters Demo Started");

        Console.WriteLine("Categories with Named Query Filters Completed");

        UserInput.WaitForUserInput();
    }
}
