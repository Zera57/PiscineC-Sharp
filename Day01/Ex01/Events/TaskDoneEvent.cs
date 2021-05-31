using System;
using System.Collections.Generic;
using System.Text;
using Ex01.Tasks;

namespace Ex01.Events
{
	public record TaskDoneEvent : Event
	{
		public TaskDoneEvent()
		{
			state = TaskState.Done;
		}
	}
}
