using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class BulkUpdateDeleteDemos : IAsyncDemo
{
    private InventoryDbContext _db;

    public BulkUpdateDeleteDemos(InventoryDbContext context)
    {
        _db = context;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Bulk Update Items - All On Sale [original logic]",
            "Bulk Update Items - None On Sale [new Bulk Update] ",
            "Bulk Update Movies - All On Sale [new Bulk Update w/Filter]",
            "Bulk Delete Junk Data - Delete by Filter with one Operation",
            "Bulk Delete All Junk Data - Delete All with one Operation",
            "Exit"
        };
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {

        switch (choice)
        {
            case 1:
                await BulkUpdateItemsAllOnSaleOriginal();
                break;
            case 2:
                await BulkUpdateItemsNoneOnSaleNew();
                break;
            case 3:
                await BulkUpdateMoviesAllOnSaleNew();
                break;
            case 4:
                await BulkDeleteJunkDataByFilter();
                break;
            case 5:
                await BulkDeleteJunkDataAll();
                break;
            case 6:
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

            var menuText = MenuGenerator.GenerateMenu("Interceptors Demos", "Please select an operation", menuOptions, 40);

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

    private async Task BulkUpdateItemsAllOnSaleOriginal()
    {
        Console.WriteLine("Bulk Update All Items On Sale (Original Logic)");

        Console.WriteLine("Bulk Update All Items On Sale (Original Logic) Completed");

        UserInput.WaitForUserInput();
    }

    private async Task BulkUpdateItemsNoneOnSaleNew()
    {
        Console.WriteLine("Bulk Update Items - Nothing is on sale");

        Console.WriteLine("Bulk Update Items - Nothing is on sale - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task BulkUpdateMoviesAllOnSaleNew()
    {
        Console.WriteLine("Bulk Update With Filter - Movies On Sale");

        Console.WriteLine("Bulk Update With Filter - Movies On Sale - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task BulkDeleteJunkDataByFilter()
    {
        Console.WriteLine("Bulk Delete Junk Data with Filter");

        Console.WriteLine("Bulk Delete Junk Data With Filter - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task BulkDeleteJunkDataAll()
    {
        Console.WriteLine("Bulk Delete All Junk Data (no filter)");

        Console.WriteLine("Bulk Delete All Junk Data (no filter) - Completed");

        UserInput.WaitForUserInput();
    }
}
