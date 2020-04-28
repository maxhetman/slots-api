using System.Threading.Tasks;
using Application.DTO.Requests;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Xunit;

namespace UnitTests.Services
{
	public class SlotServiceTests
	{
		[Fact]
		public async Task CreateSlot_CallsRepositoryAdd()
		{
			var slotDto = new SlotDto();

			var mapperMock = new Mock<IMapper>();
			mapperMock.Setup(m => m.Map<Slot>(It.IsAny<Slot>())).Returns(It.IsAny<Slot>());

			var repositoryMock = new Mock<ISlotsRepository>();
			repositoryMock.Setup(r => r.AddAsync(It.IsAny<Slot>())).Returns(Task.CompletedTask).Verifiable();

			var slotsService = new SlotsService(repositoryMock.Object, mapperMock.Object);
			await slotsService.CreateAsync(slotDto);
			repositoryMock.Verify();
		}
	}
}
