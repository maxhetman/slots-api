using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface ISlotsRepository
	{
		Task<IEnumerable<Slot>> GetAsync(DateTime currentDate, int horizon);

		Task AddAsync(Slot slot);

		Task UpdateAsync(Slot slot);
	}
}
