// Sagt dem Code, dass er den Ordner Model verwenden soll, damit die Klassen aus diesem Ordner im Hauptprogramm verfügbar sind
using Klassen.Model;

namespace ClassExample;

class Program
{
    // Globale Variablen für die Verwaltung
    private static List<TestClass> testClassList = [];
    private static TestClass? selectedTestClass = null;

    static void Main(string[] args)
    {
        Console.WriteLine("=== TestClass ===\n");

        bool running = true;
        // Hauptschleife: Läuft bis der Benutzer das Programm beendet
        while (running)
        {
            ShowMenu();
            string? input = Console.ReadLine();
            Console.WriteLine();

            // Verarbeitet die Benutzereingabe
            switch (input)
            {
                case "1":
                    CreateTestClass();
                    break;
                case "2":
                    SelectTestClass();
                    break;
                case "3":
                    UpdateTestString();
                    break;
                case "4":
                    ReturnTestStringValue();
                    break;
                case "5":
                    CallVoidMethod();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid input! Please choose a valid option.");
                    break;
            }

            // Wartet auf Tastendruck bevor das Menü neu angezeigt wird
            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║           MAIN MENU                    ║");
        Console.WriteLine("╠════════════════════════════════════════╣");
        Console.WriteLine("║ TestClass:                             ║");
        Console.WriteLine("║ 1  - Create Test Class                 ║");
        Console.WriteLine("║ 2  - Select Test Class                 ║");
        Console.WriteLine("║ 3  - Update Test String                ║");
        Console.WriteLine("║ 4  - Return Test String Value          ║");
        Console.WriteLine("║ 5  - Void                              ║");
        Console.WriteLine("║                                        ║");
        Console.WriteLine("║ 0  - Exit                              ║");
        Console.WriteLine("╚════════════════════════════════════════╝");

        Console.Write("\nYour choice: ");
    }

    public static void CreateTestClass()
    {
        Console.Write("Enter a string value: ");
        string? testString = Console.ReadLine();
        Console.Write("Enter an integer value: ");
        string? integerInput = Console.ReadLine();
        int? integer = null;
        if (integerInput != null)
        {
            if (int.TryParse(integerInput, out int intValue))
            {
                integer = intValue;
            }
        }
        Console.WriteLine("Creating TestClass with values: " + testString + ", " + integer);
        TestClass newTestClass = new TestClass(testString ?? "Default String", integer ?? 0);
        testClassList.Add(newTestClass);
        selectedTestClass = newTestClass;
    }

    public static void SelectTestClass()
    {
        if (testClassList.Count == 0)
        {
            Console.WriteLine("No TestClass instances available. Please create one first.");
            return;
        }

        Console.WriteLine("Available TestClass instances:");
        for (int i = 0; i < testClassList.Count; i++)
        {
            string selected = (testClassList[i] == selectedTestClass) ? " [SELECTED]" : "";
            Console.WriteLine($"{i + 1}. {testClassList[i].TestString}{selected}");
        }

        Console.Write("\nSelect a TestClass (enter number): ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int index) && index > 0 && index <= testClassList.Count)
        {
            selectedTestClass = testClassList[index - 1];
            Console.WriteLine($"Selected: {selectedTestClass.TestString}");
        }
        else
        {
            Console.WriteLine("Invalid selection!");
        }
    }

    public static void UpdateTestString()
    {
        if (selectedTestClass == null)
        {
            Console.WriteLine("No TestClass selected. Please select one first.");
            return;
        }

        Console.WriteLine($"Current TestString value: {selectedTestClass.TestString}");
        Console.Write("Enter new value: ");
        string? newValue = Console.ReadLine();

        if (newValue != null)
        {
            selectedTestClass.UpdateTestString(newValue);
            Console.WriteLine($"Updated TestString to: {selectedTestClass.TestString}");
        }
        else
        {
            Console.WriteLine("No value entered. Update cancelled.");
        }
    }

    public static void ReturnTestStringValue()
    {
        if (selectedTestClass == null)
        {
            Console.WriteLine("No TestClass selected. Please select one first.");
            return;
        }

        string value = selectedTestClass.ReturnTestStringValue();
        Console.WriteLine($"TestString value: {value}");
    }

    public static void CallVoidMethod()
    {
        if (selectedTestClass == null)
        {
            Console.WriteLine("No TestClass selected. Please select one first.");
            return;
        }

        selectedTestClass.TestVoidMethod();
    }
}
