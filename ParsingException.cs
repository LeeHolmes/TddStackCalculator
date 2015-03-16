using System;

namespace StackCalculator
{
	/// <summary>
	/// Summary description for ParsingException.
	/// </summary>
	public class ParsingException : Exception
	{
		public ParsingException(string message) : base(message) {}
	}
}
