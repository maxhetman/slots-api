using Domain.Entities.Enums;
using Newtonsoft.Json;

namespace Application.DTO.Requests
{
	public class SlotDto
	{
		[JsonProperty("price")]
		public decimal Price { get; set; }

		[JsonProperty("startDatediff")]
		public int StartDatediff { get; set; }

		[JsonProperty("finishDatediff ")]
		public int FinishDatediff { get; set; }

		[JsonProperty("type")]
		public SlotType Type { get; set; }

		[JsonProperty("hoursFrom")]
		public int HoursFrom { get; set; }

		[JsonProperty("hoursTo")]
		public int HoursTo { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("hoursToAccess")]
		public int? HoursToAccess { get; set; }

		[JsonProperty("daysOfWeek")]
		public DaysOfWeek DaysOfWeek { get; set; } = DaysOfWeek.All;
	}
}
