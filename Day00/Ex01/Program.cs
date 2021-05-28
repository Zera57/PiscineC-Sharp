using System;
using System.Text.RegularExpressions;

if (!System.IO.File.Exists("names.txt"))
{
	Console.WriteLine("Cannot find names.txt");
	return;
}
string[] namesDB = System.IO.File.ReadAllLines("names.txt");
int[] distanceDB = new int[namesDB.Length];

Console.WriteLine("Enter name:");
string inputS = Console.ReadLine().Trim();
if (!validateName(inputS))
{
	Console.WriteLine("Not valid name");
	return;
}

for (int i = 0; i < namesDB.Length; i++)
{
	distanceDB[i] = levensteinDistance(inputS, namesDB[i]);
	if (distanceDB[i] == 0)
	{
		Console.WriteLine($"Hello, {inputS}!");
		return;
	}
}
int minDistance = 3;
for (int i = 0; i < distanceDB.Length; i++)
{
	if (minDistance > distanceDB[i])
	{
		minDistance = distanceDB[i];
	}
}
for (int i = 0; i < distanceDB.Length; i++)
{
	if (distanceDB[i] == minDistance)
	{
		Console.WriteLine($"Did you mean {namesDB[i]}?");
		if (Console.ReadLine().CompareTo("Y") == 0)
		{
			Console.WriteLine($"Hello, {namesDB[i]}!");
			return;
		}
	}
}
Console.WriteLine("Your name was not found.");

bool validateName(string name)
{
	if (name.Length == 0)
		return (false);
	return Regex.Match(name, "^[A-Za-z]*-?[A-Za-z]*$").Success;
}

int levensteinDistance(string a, string b)
{
	int[,] f = new int[a.Length + 1, b.Length + 1];

	for (int i = 0; i < a.Length + 1; i++)
	{
		for (int j = 0; j < b.Length + 1; j++)
		{
			if (i * j == 0)
				f[i, j] = i + j;
		}
	}
	for (int i = 1; i < a.Length + 1; i++)
	{
		for (int j = 1; j < b.Length + 1; j++)
		{
			if (a[i - 1] == b[j - 1])
				f[i, j] = f[i - 1, j - 1];
			else
				f[i, j] = 1 + Math.Min(Math.Min(f[i - 1, j], f[i, j - 1]), f[i - 1, j - 1]);
		}
	}
	return (f[a.Length, b.Length]);
}
