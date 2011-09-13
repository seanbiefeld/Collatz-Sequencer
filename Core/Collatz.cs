namespace Core
{
	public class Collatz
	{
		public static double Calculate(double number)
		{
			if (number % 2 == 1)
				number = (3 * number) + 1;
			else
				number = number / 2;
			return number;
		}
	}
}