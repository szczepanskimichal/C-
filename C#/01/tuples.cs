partial class Program
{
	static void Main()
	{
		var point = (X: 1, Y: 2);
		var slope = (double)point.Y / point.X;
		System.Console.WriteLine($"{point} The slope is {slope}");
	}
}