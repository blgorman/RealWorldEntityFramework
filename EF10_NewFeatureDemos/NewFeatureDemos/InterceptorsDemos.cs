
using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class InterceptorsDemos : IAsyncDemo
{
    private InventoryDbContext _db;

    public InterceptorsDemos(InventoryDbContext context)
    {
        _db = context;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "LoggingInterceptor",
            "SoftDeleteInterceptor",
            "Exit"
        };
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {

        switch (choice)
        {
            case 1:
                await ShowLoggingInterceptor();
                break;
            case 2:
                await ShowSoftDeleteInterceptor();
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

    private async Task ShowLoggingInterceptor()
    {
        Console.WriteLine("Logging Interceptor");

        Console.WriteLine("Logging Interceptor Completed");

        UserInput.WaitForUserInput();
    }

    private async Task ShowSoftDeleteInterceptor()
    {
        Console.WriteLine("Soft Delete Interceptor");

        Console.WriteLine("Soft Delete Interceptor Completed");

        UserInput.WaitForUserInput();
    }
}
