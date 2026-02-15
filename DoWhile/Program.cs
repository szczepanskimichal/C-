Random random = new Random();
int current=random.Next(1,11);
//int current =0;

do
{
   current=random.Next(1, 11);
   
   if(current>=8) continue;
   
   Console.WriteLine(current);
} while (current != 7);
/*
while (current >= 3)
{
   Console.WriteLine(current);
   current = random.Next(1, 11);
}

Console.WriteLine($"Last number generated was {current}");
*/