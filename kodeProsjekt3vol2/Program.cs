string? readResult;
string roleName="";
bool validRole=false;

do
{
    Console.WriteLine("Enter a role name (Admin, User, Guest)");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        roleName = readResult.Trim();
    }
    if(roleName.ToLower() == "admin" || roleName.ToLower() == "user" || roleName.ToLower() == "guest")
    {
        validRole = true;
    }
    else
    {
        Console.WriteLine($"You entered {roleName} is not valid. Please enter a valid role name (Admin, User, Guest)");
    }
} while (validRole==false);

Console.WriteLine($"Your input value({roleName}) has been accepted!");
readResult = Console.ReadLine();