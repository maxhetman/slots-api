using Application.DTO.Requests;
using Application.DTO.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/slots")]
	public class SlotsController : ControllerBase
	{
		private readonly ISlotsService _slotsService;

		public SlotsController(ISlotsService slotsService)
		{
			_slotsService = slotsService;
		}

		[HttpGet]
		public async Task<IEnumerable<SlotViewDto>> GetAvailableSlots(DateTime? currentDate, int horizon)
		{
			if (!currentDate.HasValue)
				currentDate = DateTime.UtcNow;

			return await _slotsService.GetAllViewsAsync(currentDate.Value, horizon);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSlot(SlotDto slotDto)
		{
			await _slotsService.CreateAsync(slotDto);
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSlot(int id, [FromBody] SlotDto slotDto)
		{
			await _slotsService.UpdateAsync(id, slotDto);
			return Ok();
		}

	}
}
