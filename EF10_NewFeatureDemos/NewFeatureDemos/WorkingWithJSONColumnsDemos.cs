using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class WorkingWithJSONColumnsDemos : IAsyncDemo
{
    private InventoryDbContext _db;

    public WorkingWithJSONColumnsDemos(InventoryDbContext context)
    {
        _db = context;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Original JSON Column Demo",
            "Get Contributors by City",
            "Get Contributors with Address having 'P.O. Box'",
            "Exit"
        };
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {

        switch (choice)
        {
            case 1:
                await ShowOriginalJSONQueryLogic();
                break;
            case 2:
                await GetContributorsByCity();
                break;
            case 3:
                await GetContributorsWithPOBoxAddress();
                break;
            case 4:
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

    private async Task ShowOriginalJSONQueryLogic()
    {
        Console.WriteLine("Logging Interceptor");

        Console.WriteLine("Logging Interceptor Completed");

        UserInput.WaitForUserInput();
    }

    private async Task GetContributorsByCity()
    {
        Console.WriteLine("Soft Delete Interceptor");

        Console.WriteLine("Soft Delete Interceptor Completed");

        UserInput.WaitForUserInput();
    }

    private async Task GetContributorsWithPOBoxAddress()
    {
        Console.WriteLine("Soft Delete Interceptor");

        Console.WriteLine("Soft Delete Interceptor Completed");

        UserInput.WaitForUserInput();
    }
}
