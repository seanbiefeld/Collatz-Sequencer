using System;
using Core;

namespace CollatzSequencer
{
	class Program
	{
		static void Main()
		{
			GetNumberFromInput();
		}

		static void GetNumberFromInput()
		{
			Console.WriteLine("Give me any positive integer greater than zero. To exit type 'exit'");

			string consoleInput = Console.ReadLine();

			while (consoleInput != null && consoleInput.ToLower().Trim() != "exit")
			{
				double number = 0;

				bool isValidNumber;

				number = ValidateInput(consoleInput, number, out isValidNumber);

				if (isValidNumber)
				{
					double initialNumber = number;

					PerformCollatzSequence(number);

					Console.WriteLine(string.Format("\n------------End Sequence for {0}------------\n", initialNumber));
				}

				consoleInput = null;
				GetNumberFromInput();
			}
		}

		static double ValidateInput(string consoleInput, double number, out bool valid)
		{
			valid = false;

			bool numberWasParsable = true;

			try
			{
				number = double.Parse(consoleInput);
			}
			catch (Exception)
			{
				numberWasParsable = false;
			}

			if (numberWasParsable)
			{
				number = Math.Round(number, 0);

				if (number < 0)
				{
					Console.WriteLine("You fail! I want a positive integer.");
				}
				else if (number == 0)
				{
					Console.WriteLine("You fail! I want an integer greater than zero.");
				}
				else
				{
					valid = true;
				}
			}
			else
			{
				Console.WriteLine("You fail! That's not an integer, try again:");
			}

			return number;
		}

		static void PerformCollatzSequence(double number)
		{
			Console.WriteLine(string.Format("\n-----------Begin Sequence for {0}-----------\n", number));

			int counter = 0;

			double maxValue = number;

			bool finalStepReached = false;

			while (number >= 1 && !finalStepReached)
			{
				if(counter == 0)
					Console.Write(string.Format("> {0}",number));

				number = Collatz.Calculate(number);

				Console.Write(string.Format(", {0}", number));

				if(number == 1)
					finalStepReached = true;

				if(number > maxValue)
					maxValue = number;

				counter++;
			}

			Console.WriteLine(string.Format("\n\nThis sequence has {0} step(s).", counter));
			Console.WriteLine(string.Format("The max number in this sequence was {0}.", maxValue));
		}
	}
}