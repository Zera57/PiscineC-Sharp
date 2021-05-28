using System;
using System.Collections.Generic;
using System.Text;

namespace Ex00.Models
{
	public struct ExchangeRate
	{
		string _id;
		string _idTo;
		double _rate;

		public string Id => _id;
		public string IdTo => _idTo;
		public double Rate => _rate;


		public ExchangeRate(string id, string idTo, double rate)
		{
			_id = id.ToUpper();
			_idTo = idTo.ToUpper();
			_rate = rate;
		}

		public override string ToString()
		{
			return $"Сумма в {_idTo}: {_rate:f2} {_idTo}";
		}
	}
}
