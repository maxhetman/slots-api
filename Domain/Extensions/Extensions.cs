using Domain.Entities.Enums;
using System;

namespace Domain.Extensions
{
	public static class Extensions
	{
		private static readonly DateTime FirstDay = new DateTime(1970, 1, 1);

		public static int GetDateDiff(this DateTime dateTime)
			=> (dateTime - FirstDay).Days;

		//not very elegant and hard to test, need to refactor in future
		public static DateTime ToDateTime(this int dateDiff)
			=> FirstDay.AddDays(dateDiff);

		public static DaysOfWeek GetDayOfWeek(this DateTime dateTime)
			=> Enum.Parse<DaysOfWeek>(dateTime.DayOfWeek.ToString());
	}
}
