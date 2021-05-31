using System;
using Ex00.Models;

namespace Ex00
{
	class Program
	{
		static void Main(string[] args)
		{
			double sum;
			if (!double.TryParse(args[0].Split(' ')[0], out sum))
				return;
			Exchanger.Update(args[1]);

			ExchangeSum exchange = new ExchangeSum(args[0].Split(' ')[1], sum);
			foreach (ExchangeRate item in Exchanger.GetExchangeRates(exchange))
			{
				Console.WriteLine(item.ToString());
			}
		}
	}
}
