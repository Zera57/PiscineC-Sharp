using System;
using System.Collections.Generic;
using System.Text;
using Ex01.Tasks;

namespace Ex01.Events
{
	public abstract record Event
	{
		public TaskState state { get; protected init; }
	}
}
