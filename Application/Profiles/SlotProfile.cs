using Application.DTO.Requests;
using Application.DTO.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
	public class SlotProfile : Profile
	{
		public SlotProfile()
		{
			CreateMap<Slot, SlotViewDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
				.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString().ToLowerInvariant()))
				.ForMember(dest => dest.Start,
					opt => opt.MapFrom((src, dst, _, ctx) => ctx.Items[nameof(SlotViewDto.Start)]))
				.ForMember(dest => dest.Finish,
					opt => opt.MapFrom((src, dst, _, ctx) => ctx.Items[nameof(SlotViewDto.Finish)]))
				.ForMember(dest => dest.Available,
					opt => opt.MapFrom((src, dst, _, ctx) => ctx.Items[nameof(SlotViewDto.Available)]));

			CreateMap<SlotDto, Slot>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(TryGetIdFromContext))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
				.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
				.ForMember(dest => dest.FinishDatediff, opt => opt.MapFrom(src => src.FinishDatediff))
				.ForMember(dest => dest.StartDatediff, opt => opt.MapFrom(src => src.StartDatediff))
				.ForMember(dest => dest.HoursFrom, opt => opt.MapFrom(src => src.HoursFrom))
				.ForMember(dest => dest.HoursTo, opt => opt.MapFrom(src => src.HoursTo))
				.ForMember(dest => dest.HoursToAccess, opt => opt.MapFrom(src => src.HoursToAccess))
				.ForMember(dest => dest.DaysOfWeek, opt => opt.MapFrom(src => src.DaysOfWeek));
		}

		private int TryGetIdFromContext(SlotDto src, Slot dest, int destIt, ResolutionContext context)
		{
			if (context.Items.TryGetValue(nameof(Slot.Id), out var id))
				return (int) id;

			return 0;
		}
	}
}
