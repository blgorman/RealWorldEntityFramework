using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class LINQEnhancementsDemos : IAsyncDemo
{
    private InventoryDbContext _db;

    public LINQEnhancementsDemos(InventoryDbContext context)
    {
        _db = context;
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

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Show N Plus One Query",
            "Fix N Plus One Query",
            "Prefetch IEnumerable",
            "One Fetch Only",
            "Show Contributor Data Report [old way -> Group Join and Select Many",
            "Show Contributor Data Report [new way -> Left Join]",
            "Something else?",
            "Better than something else?",
            "Exit"
        };
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {

        switch (choice)
        {
            case 1:
                await ShowNPlusOneQuery();
                break;
            case 2:
                await FixNPlusOneQuery();
                break;
            case 3:
                await PrefetchIEnumerable();
                break;
            case 4:
                await OneFetchOnly();
                break;
            case 5:
                await ShowContributorDataReportOldLogic();
                break;
            case 6:
                await ShowContributorDataReportNewLogic();
                break;
            case 7:
                await SomethingElseImSure();
                break;
            case 8:
                await BetterThanSomethingElse();
                break;
            case 9:
                return false;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
        return true;
    }

    private async Task ShowNPlusOneQuery()
    {
        Console.WriteLine("N Plus One Query");

        Console.WriteLine("N Plus One Query Completed");

        UserInput.WaitForUserInput();
    }

    private async Task FixNPlusOneQuery()
    {
        Console.WriteLine("Fix N Plus One Query");

        Console.WriteLine("Fix N Plus One Query Completed");

        UserInput.WaitForUserInput();
    }

    private async Task PrefetchIEnumerable()
    {
        string heading = "Pre-Fetching an IEnumerable";
        Console.WriteLine(heading);

        Console.WriteLine($"{heading} - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task OneFetchOnly()
    {
        string heading = "Fetch only once";
        Console.WriteLine(heading);

        Console.WriteLine($"{heading} - Completed");

        UserInput.WaitForUserInput();
    }
    private async Task ShowContributorDataReportOldLogic()
    {
        string heading = "Contributor Data Report (using Group Join, Select Many, and Group By)";
        Console.WriteLine(heading);

        Console.WriteLine($"{heading} - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task ShowContributorDataReportNewLogic()
    {
        string heading = "Contributor Data Report (using Left Join, Group By, and Select)";
        Console.WriteLine(heading);

        Console.WriteLine($"{heading} - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task SomethingElseImSure()
    {
        string heading = "Soething Else";
        Console.WriteLine(heading);

        Console.WriteLine($"{heading} - Completed");

        UserInput.WaitForUserInput();
    }

    private async Task BetterThanSomethingElse()
    {
        string heading = "Better than Something Else";
        Console.WriteLine(heading);

        Console.WriteLine($"{heading} - Completed");

        UserInput.WaitForUserInput();
    }
}
