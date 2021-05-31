using System;
using System.Collections.Generic;
using System.Text;
using Ex01.Events;

namespace Ex01.Tasks
{
	public class Task
	{
		List<Event> _state = new List<Event>();
		string _title;
		string _summary;
		DateTime? _dueData;
		TaskType _type;
		TaskPriority _priority = TaskPriority.Normal;

		public TaskState State => _state[_state.Count - 1].state;
		public string Title { get => _title; set => _title = value; }
		public string Summary { get => _summary; set => _summary = value; }
		public DateTime? DueDate { get => _dueData; set => _dueData = value; }
		internal TaskType Type { get => _type; set => _type = value; }
		internal TaskPriority Priority { get => _priority; set => _priority = value; }

		public Task()
		{
			_state.Add(new CreatedEvent());
		}

		public bool Done()
		{
			if (_state.Count == 1)
				_state.Add(new TaskDoneEvent());
			else
				return false;
			return true;
		}

		public bool WontDo()
		{
			if (_state.Count == 1)
				_state.Add(new TaskWontDoEvent());
			else
				return false;
			return true;
		}

	}
}
