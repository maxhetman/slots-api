﻿using System;

namespace Domain.Entities.Enums
{
	[Flags]
	public enum DaysOfWeek
	{
		Monday = 1,
		Tuesday = 2,
		Wednesday = 4,
		Thursday = 8,
		Friday = 16,
		Saturday = 32,
		Sunday = 64,
		All = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
	}
}
