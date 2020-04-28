using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class SlotsRepository : ISlotsRepository
	{
		private readonly SlotsContext _context;

		public SlotsRepository(SlotsContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Slot>> GetAsync(DateTime currentDate, int horizon)
		{
			var lastDateDiff = currentDate.GetDateDiff() + horizon;

			return await _context.Slots
				.Where(s => lastDateDiff <= s.FinishDatediff)
				.ToListAsync();
		}

		public async Task AddAsync(Slot slot)
		{
			await _context.Slots.AddAsync(slot);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Slot slot)
		{
			var slotEntry = await _context.Slots.FindAsync(slot.Id);

			if (slotEntry != null)
			{
				_context.Entry(slotEntry).CurrentValues.SetValues(slot);
				await _context.SaveChangesAsync();
			}
		}
	}
}
