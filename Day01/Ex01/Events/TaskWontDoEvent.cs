using System;
using System.Collections.Generic;
using System.Text;
using Ex01.Tasks;

namespace Ex01.Events
{
	public record TaskWontDoEvent : Event
	{
		public TaskWontDoEvent()
		{
			state = TaskState.Notrelevant;
		}
	}
}
