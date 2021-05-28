using System;
using Ex00.Models;

namespace Ex00
{
	class Program
	{
		static void Main(string[] args)
		{
			double sum;
			if (!double.TryParse(args[1], out sum))
				return;
			Exchanger.Update("rates");
			foreach (ExchangeRate item in Exchanger.GetExchangeRates(new ExchangeSum(args[0], sum)))
			{
				Console.WriteLine(item.ToString());
			}
		}
	}
}
