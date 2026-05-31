using KlasserStatic;

class Program
{
    public static void Main(string[] args)
    {
        /*        int[] myNumbers = { 1, 2, 3, 4, 5 };

        //List<int> numbers = new List<int>(myNumbers);
        List<string> names = [];
        names.Add("Alice");
        names.Add("Bob");
        names.Add("Charlie");
        names.Add("David");
        names.Add("Eve");
        //names.Remove(names[1]);
        //Console.WriteLine($"Numbers in the list: {myNumbers.Length}");
        Console.WriteLine(names.Count);
        Console.WriteLine(names[0]);
        Console.WriteLine(myNumbers.Length);
        string findName = names.Find(names => names == "Charlie");
        Console.WriteLine(findName);
        bool exists = names.Contains("David");
        Console.WriteLine(exists);

*/

        
        // List<string> names = new List<string>{"Michal", "Ada", "Mia"};
        // for (int i = 0; i < names.Count; i++)
        // {
        //     Console.WriteLine(names[i].ToUpper());
        // }
        //
        // foreach (var name in names)
        // {
        //     Console.WriteLine(name.ToLower());
        // }

        List<string> names = new List<string>();
        while (true)
        {
            Console.WriteLine("This is the kontakt consoleApp");
            Console.WriteLine("Type in your name:");
            Console.WriteLine("Choose 1 to add a person");
            Console.WriteLine("Choose 2 to remove person");
            Console.WriteLine("3 Show list of names:");
            Console.WriteLine("4 Type name to find it in our base:");
            Console.WriteLine("5 Exit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    names.Add(name);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the name you want to remove:");
                    string name = Console.ReadLine();
                    names.Remove(name);
                }
                else if (input == "3")
                {
                    Console.Clear();
                    foreach (var name in names)
                    {
                        Console.WriteLine(name);
                    }
                }
                else if (input == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Enter the name you want to find: ");
                    string query= Console.ReadLine();
                    string existInBase = names.Find(name => name == query);
                    var ExistInBaseId = names.IndexOf(existInBase);
                    Console.WriteLine($"{existInBase} is found in the base with index {ExistInBaseId}");
                    
                }
                else if (input == "5")
                {
                    Console.WriteLine("GoodBye");
                    Console.Clear();
                    break;
                }
                
        }
    }
}