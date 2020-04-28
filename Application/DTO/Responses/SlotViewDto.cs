using System;
using Newtonsoft.Json;

namespace Application.DTO.Responses
{
	public class SlotViewDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("start")]
		public DateTime Start { get; set; }

		[JsonProperty("finish")]
		public DateTime Finish { get; set; }

		[JsonProperty("price")]
		public decimal Price { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("available")]
		public bool Available { get; set; }
	}
}
