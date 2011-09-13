using Core;
using Machine.Specifications;

namespace CollatzSequencer.Specs
{
	public class CollatzContext
	{
		protected static double _calculationResult;
	}

	[Subject("collatz sequence calculation")]
	public class when_calculating_with_an_even_positive_integer : CollatzContext
	{
		static double _evenPositiveInteger;

		Establish context = () =>
			_evenPositiveInteger = 10.0;

		Because of = () =>
			_calculationResult = Collatz.Calculate(_evenPositiveInteger);

		It should_return_the_result_of_a_division_by_two = () =>
			_calculationResult.ShouldEqual(5.0);
	}

	[Subject("collatz sequence calculation")]
	public class when_calculating_with_an_odd_positive_integer : CollatzContext
	{
		static double _oddPositiveInteger;

		Establish context = () =>
			_oddPositiveInteger = 3.0;

		Because of = () =>
			_calculationResult = Collatz.Calculate(_oddPositiveInteger);

		It should_multiply_by_three_and_add_one = () =>
			_calculationResult.ShouldEqual(10.0);
	}
}