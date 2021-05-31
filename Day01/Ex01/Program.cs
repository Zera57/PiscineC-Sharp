using System;
using System.Collections.Generic;
using Ex01.Tasks;

namespace Ex01
{
	class Program
	{
		static List<Task> tasks = new List<Task>();

		static void Main(string[] args)
		{
			string input;
			while ((input = Console.ReadLine()).CompareTo("quit") != 0)
			{
				if (input.CompareTo("add") == 0)
					AddTask();
				else if (input.CompareTo("list") == 0)
					ListTasks();
				else if (input.CompareTo("done") == 0)
					DoneTask();
				else if (input.CompareTo("wontdo") == 0)
					WontDoTask();
			}
		}

		static void AddTask()
		{
			Task task = new Task();
			bool valid = true;
			DateTime dateTime;
			TaskType type;
			TaskPriority priority;

			Console.WriteLine("Введите заголовок");
			if ((task.Title = Console.ReadLine()).Length == 0)
				valid = false;

			Console.WriteLine("Введите описание");
			task.Summary = Console.ReadLine();

			Console.WriteLine("Введите срок");
			if (DateTime.TryParse(Console.ReadLine(), out dateTime))
				task.DueDate = dateTime;
			else
				task.DueDate = null;

			Console.WriteLine("Введите тип");
			if (Enum.TryParse(Console.ReadLine(), out type))
				task.Type = type;
			else
				valid = false;

			Console.WriteLine("Установите приоритет");
			if (Enum.TryParse(Console.ReadLine(), out priority))
				task.Priority = priority;

			if (valid)
			{
				tasks.Add(task);
				PrintTask(task);
			}
			else
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
		}

		static void ListTasks()
		{
			foreach (var task in tasks)
			{
				PrintTask(task);
			}
		}

		static void DoneTask()
		{
			Console.WriteLine("Введите заголовок");
			Task task = tasks.Find(task => task.Title.CompareTo(Console.ReadLine()) == 0);

			if (task == null)
			{
				Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
				return;
			}
			if (!task.Done())
			{
				Console.WriteLine("Задача уже не актуальна!");
				return;
			}
			Console.WriteLine($"Задача [{task.Title}] выполнена!");
		}

		static void WontDoTask()
		{
			Console.WriteLine("Введите заголовок");
			Task task = tasks.Find(task => task.Title.CompareTo(Console.ReadLine()) == 0);

			if (task == null)
			{
				Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
				return;
			}
			if (!task.WontDo())
			{
				Console.WriteLine("Задача уже сделанна!");
				return;
			}
			Console.WriteLine($"Задача [{task.Title}] более не актуальна!");
		}

		static void PrintTask(Task task)
		{
			Console.WriteLine(task.Title);
			Console.WriteLine($"[{task.Type}][{task.State}]");
			Console.Write($"Priority: {task.Priority}");
			if (task.DueDate != null)
				Console.Write($", Due till {((DateTime)task.DueDate).ToString("MM/dd/yy")}");
			Console.WriteLine();
			Console.WriteLine(task.Summary);
		}
	}
}
