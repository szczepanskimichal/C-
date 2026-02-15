using System.Reflection;

int employeeLevel = 100;
string employeeName ="Michal Szczepanski";
string title = "";

switch (employeeLevel)
{
    case 100 :       
    case 200 :
        title="Senior Associate";
        break;
    case 300 :
        title="Manager";
        break;
    case 400 :
        title="Senior Manager";
        break;
    default:
        title="Associate";
        break;
}

Console.WriteLine($"{employeeName}, {title}");