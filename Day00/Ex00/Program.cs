using System;


double sum;							// Сумма кредита, р
double totalDebt;					// Сумма общего долга - сумма основного долга на дату расчета.
double rate;						// Годовая процентная ставка, %
double rateMonth;					// i — процентная ставка по займу в месяц.
int term;							// Количество месяцев кредита
int selectedMonth;					// Номер месяца кредита, в котором вносится досрочный платёж
double payment;						// Сумма досрочного платежа, р
double paymentMonth;				// Аннуитетный платеж
double paymentPercentage;			// Проценты ежемесячного платежа
double totalPercentage = 0;           // Переплата
bool parsing = true;				// Флаг введенных данных
if (args.Length != 5)
{
	Console.WriteLine("Error you must have exactly 5 args!");
	return;
}
parsing &= double.TryParse(args[0], out sum);
parsing &= double.TryParse(args[1], out rate);
parsing &= int.TryParse(args[2], out term);
parsing &= int.TryParse(args[3], out selectedMonth);
parsing &= double.TryParse(args[4], out payment);
if (!parsing)
{
	Console.WriteLine("Error you must have valid args!");
	return;
}
totalDebt = sum;
rateMonth = rate / 12 / 100;
while(totalDebt > 0)
{
	paymentMonth = (sum * rateMonth * Math.Pow(1 + rateMonth, term))
						/ (Math.Pow(1 + rateMonth, term) - 1);

	paymentPercentage = (totalDebt * rateMonth * DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month))
							/ (100 * (DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365));
	totalPercentage += paymentMonth / 100 * paymentPercentage;
	totalDebt -= paymentMonth - (paymentMonth / 100 * paymentPercentage);
	Console.Write(" Payment = " + Math.Round(paymentMonth));
	Console.Write("\t\tclosing sum = " + (paymentMonth - (paymentMonth / 100 * paymentPercentage)));
	Console.WriteLine("\t\tPercentage = " + Math.Round(paymentMonth / 100 * paymentPercentage));
	Console.WriteLine("Total debt " + totalDebt);
}
Console.WriteLine("Total pereplata " + totalPercentage);
