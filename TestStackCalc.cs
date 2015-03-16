using System;
using NUnit.Framework;

namespace StackCalculator
{
	/// <summary>
	/// Summary description for TestStackCalc.
	/// </summary>
	[TestFixture]
	public class TestStackCalc
	{
		[Test]
		public void RunMe()
		{
		}

		[Test]
		public void GetSimple()
		{
			Assertion.AssertEquals(1, SCalc.Evaluate("1"));
		}

		[Test]
		[ExpectedException(typeof(ParsingException))]
		public void ParseError()
		{
			SCalc.Evaluate("ParseMe");
		}

		[Test]
		public void AddSimple()
		{
			Assertion.AssertEquals(2, SCalc.Evaluate("1 1 +"));
		}

		[Test]
		[ExpectedException(typeof(ParsingException))]
		public void AddError()
		{
			Assertion.AssertEquals(2, SCalc.Evaluate("1 1 3"));
		}

		[Test]
		public void AllowsBrackets()
		{
			Assertion.AssertEquals(1, SCalc.Evaluate("(1)"));
		}

		[Test]
		[ExpectedException(typeof(ParsingException))]
		public void DetectsOverflow()
		{
			SCalc.Evaluate("((1)");
		}

		[Test]
		[ExpectedException(typeof(ParsingException))]
		public void DetectsUnderflow()
		{
			SCalc.Evaluate("(1))");
		}

		[Test]
		public void AllowsBracketMath()
		{
			Assertion.AssertEquals(2, SCalc.Evaluate("(1) (1) +"));
		}

		[Test]
		public void AllowsBracketMath2()
		{
			Assertion.AssertEquals(2, SCalc.Evaluate("((1) (1) +)"));
		}

		[Test]
		public void AllowsBracketMath3()
		{
			Assertion.AssertEquals(4, SCalc.Evaluate("(((((((1 2 +) (1) +))))))"));
		}

		[Test]
		public void WhitespaceFriendly()
		{
			Assertion.AssertEquals(1, SCalc.Evaluate(" 1"));
		}
	}
}
