using System;
using System.Collections.Generic;
using System.Text;
using Ex01.Tasks;

namespace Ex01.Events
{
	public record CreatedEvent : Event
	{
		public CreatedEvent()
		{
			state = TaskState.New;
		}
	}
}
