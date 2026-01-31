/*
Random dice = new Random();
int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);
int total = roll1 + roll2 + roll3;
Console.WriteLine($"Dice rolls: {roll1}, {roll2}, {roll3}");
if((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
    {
    if ((roll1 == roll2) && (roll2 == roll3))
        {
            Console.WriteLine($"You rolled doubles! Your total is {total}");
            total += 6;
        }
        else
        {
            Console.WriteLine($"Your total is {total}");
            //total += 6;
        }
    }
*/
string str = "The quick brown fox jumps over the lazy dog.";
char[] charMessage = str.ToCharArray();
Array.Reverse(charMessage);
//Console.WriteLine(charMessage);
int x=0;
foreach (char i in  str)
{

    if (i == 't' || i == 'T')
    {
        x++;
        Console.WriteLine($"'o' is here { x}");
    }
}
string newMessage = new string(charMessage);
Console.WriteLine(newMessage);
Console.WriteLine($"'o' is here { x}");
