using Application.DTO.Requests;
using Application.DTO.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Extensions;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
	public class SlotsService : ISlotsService
	{
		private readonly ISlotsRepository _slotsRepository;
		private readonly IMapper _mapper;

		public SlotsService(ISlotsRepository slotsRepository, IMapper mapper)
		{
			_slotsRepository = slotsRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<SlotViewDto>> GetAllViewsAsync(DateTime currentDate, int horizon)
		{
			var slotsViews = new List<SlotViewDto>();
			var slots = await _slotsRepository.GetAsync(currentDate, horizon);

			foreach (var slot in slots)
			{
				slotsViews.AddRange(GetSlotViews(slot, currentDate, horizon));
			}

			return slotsViews;
		}

		public IEnumerable<SlotViewDto> GetSlotViews(Slot slot, DateTime currentDate, int horizon)
		{
			var slotViews = new List<SlotViewDto>();

			var currentDateDiff = currentDate.GetDateDiff();
			var stareDateDiff = Math.Max(slot.StartDatediff, currentDateDiff);
			var lastDateDiff = slot.Type == SlotType.Urgent
				? stareDateDiff
				: Math.Min(currentDateDiff + horizon, slot.FinishDatediff);

			for (int dateDiff = stareDateDiff; dateDiff <= lastDateDiff; dateDiff++)
			{
				if (!slot.IsEnabledForDay(dateDiff))
					continue;

				var finishDate = slot.GetFinishDateTime(dateDiff, currentDate);

				if (finishDate < currentDate)
					continue;

				var slotView = _mapper.Map<SlotViewDto>(slot, opt =>
				{
					opt.Items[nameof(SlotViewDto.Start)] = slot.GetStartDateTime(dateDiff, currentDate);
					opt.Items[nameof(SlotViewDto.Finish)] = finishDate;
					opt.Items[nameof(SlotViewDto.Available)] = slot.IsAvailable(dateDiff, currentDate);
				});
				slotViews.Add(slotView);
			}

			return slotViews;
		}

		public async Task CreateAsync(SlotDto slotDto)
		{
			var slot = _mapper.Map<Slot>(slotDto, _ => {});
			await _slotsRepository.AddAsync(slot);
		}

		public async Task UpdateAsync(int slotId, SlotDto slotViewDto)
		{
			var slot = _mapper.Map<Slot>(slotViewDto, opt => opt.Items[nameof(Slot.Id)] = slotId);
			await _slotsRepository.UpdateAsync(slot);
		}
	}
}
