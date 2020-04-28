using Domain.Entities.Enums;
using Domain.Extensions;
using System;

namespace Domain.Entities
{
	public class Slot
	{
		//from technical requirements meaning of this value was not perfectly clear.
		//it should be moved either to DB or to configuration file after discussion.
		//For now const would be fine
		private const int UrgentDeliveryDuration = 2;

		public int Id { get; private set; }

		public decimal Price { get; private set; }

		public int StartDatediff { get; private set; }

		public int FinishDatediff { get; private set; }

		public SlotType Type { get; private set; }

		public int HoursFrom { get; private set; }

		public int HoursTo { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public int? HoursToAccess { get; private set; }

		public DaysOfWeek DaysOfWeek { get; private set; }

		public bool IsAvailable(int dateDiff, DateTime currentDate)
			=> IsEnabledForDay(dateDiff) && HoursToAccessAreValid(dateDiff, currentDate);

		public bool IsEnabledForDay(int dateDiff)
		{
			var isInDateDiffBoundaries = dateDiff >= StartDatediff && dateDiff <= FinishDatediff;

			if (!isInDateDiffBoundaries)
				return false;

			var date = dateDiff.ToDateTime();
			return DaysOfWeek.HasFlag(date.GetDayOfWeek());
		}

		public DateTime GetStartDateTime(int dateDiff, DateTime currentDate)
		{
			var dt = dateDiff.ToDateTime();
			var startDatetime = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
			var startHours = Type == SlotType.Urgent ? currentDate.Hour : HoursFrom;

			return startDatetime.AddHours(startHours);
		}

		public DateTime GetFinishDateTime(int dateDiff, DateTime currentDate)
		{
			var dt = dateDiff.ToDateTime();
			var finishDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
			var finishHours = Type == SlotType.Urgent ? currentDate.Hour + UrgentDeliveryDuration : HoursTo;

			return finishDateTime.AddHours(finishHours);
		}

		private bool HoursToAccessAreValid(int dateDiff, DateTime currentDate)
		{
			if (Type == SlotType.Urgent)
				return currentDate.Hour >= HoursFrom && currentDate.Hour <= HoursTo;

			var dt = dateDiff.ToDateTime();
			var slotStartDate = new DateTime(dt.Year, dt.Month, dt.Day, HoursFrom, 0, 0);
			var hoursDiff = (slotStartDate - currentDate).TotalHours;

			return hoursDiff >= HoursToAccess;
		}
	}
}
