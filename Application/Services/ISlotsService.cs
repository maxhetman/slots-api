using Application.DTO.Requests;
using Application.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services
{
	public interface ISlotsService
	{
		Task<IEnumerable<SlotViewDto>> GetAllViewsAsync(DateTime currentDate, int horizon);

		IEnumerable<SlotViewDto> GetSlotViews(Slot slot, DateTime currentDate, int horizon);
		
		Task CreateAsync(SlotDto slotDto);

		Task UpdateAsync(int slotId, SlotDto slotDto);
	}
}
