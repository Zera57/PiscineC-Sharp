using System;
using System.Collections.Generic;
using System.Text;

namespace Ex00.Models
{
	public struct ExchangeSum
	{
		private string _id;
		private double _sum;

		public string Id => _id;
		public double Sum => _sum;

		public ExchangeSum(string id, double sum)
		{
			_id = id.ToUpper();
			_sum = sum;
		}

		public override string ToString()
		{
			return $"{_sum} {_id}";
		}
	}
}
