using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ex00.Models;

namespace Ex00
{
	public static class Exchanger
	{
		static List<ExchangeRate> _exchangeRates = new List<ExchangeRate>();

		public static IEnumerable GetExchangeRates(ExchangeSum exchangeSum)
		{
			List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

			foreach (var rate in _exchangeRates)
			{
				if (rate.Id.CompareTo(exchangeSum.Id) == 0)
				{
					yield return new ExchangeRate(rate.Id, rate.IdTo, rate.Rate * exchangeSum.Sum);
				}
			}
		}

		public static void Update(string path)
		{
			_exchangeRates.Clear();
			try
			{
				foreach (var filePath in System.IO.Directory.GetFiles(path))
				{
					string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
					foreach (var line in System.IO.File.ReadAllLines(filePath))
					{
						string[] tempString = line.Split(':');
						double sum;
						if (double.TryParse(tempString[1], out sum))
							_exchangeRates.Add(new ExchangeRate(fileName, tempString[0], sum));
					}
				}
			}
			catch
			{

			}
		}

	}
}
