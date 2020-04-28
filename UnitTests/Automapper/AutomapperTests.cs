using Application.Profiles;
using AutoMapper;
using Xunit;

namespace UnitTests.Automapper
{
	public class AutomapperTests
	{
		[Fact]
		public void MapperConfiguration_CheckIsValid()
		{
			var configuration = new MapperConfiguration(cfg =>
				{
					cfg.AddProfile(typeof(SlotProfile));
				}
			);

			configuration.AssertConfigurationIsValid();
		}
	}
}
