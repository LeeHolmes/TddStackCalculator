using System;

namespace StackCalculator
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class SCalc
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine(Evaluate(args[0]));
		}

		public static int Evaluate(string input)
		{
			int returnValue = 0;

			input = input.Trim();
			string[] values = SplitInput(input);

			// There was only 1 (possibly bracketed) item
			if(values[1].Length == 0)
			{
				try 
				{ 
					if(input.IndexOf("(") >= 0)
						returnValue = Evaluate(input.Substring(1, input.Length - 2));
					else
						returnValue = Convert.ToInt32(input); 
				}
				catch(FormatException) { throw new ParsingException("Could not convert to Int32: " + input); }
			}
			// There were 2 operands and an operator
			else
			{
				int value1 = Evaluate(values[0]);
				int value2 = Evaluate(values[1]);
				string operation = values[2];

				switch(operation)
				{
					case "+":
					{
						returnValue = value1 + value2;
					}; break;

					case "*":
					{
						returnValue = value1 * value2;
					}; break;

					default:
					{
						throw new ParsingException("Invalid Operation: " + operation);
					}
				}
			}

			return returnValue;
		}

		private static string[] SplitInput(string input)
		{
			string[] pieces = {"", "", ""};
			int currentPiece = 0;
			int nestLevel = 0;

			foreach(char currentChar in input)
			{
				if((currentChar == ' ') && (nestLevel == 0))
					currentPiece++;
				else
					pieces[currentPiece] += currentChar;

				if(currentChar == '(')
					nestLevel++;
				else if(currentChar == ')')
					nestLevel--;
			}

			return pieces;
		}
	}
}
