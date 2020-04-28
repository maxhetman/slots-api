using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
	public class SlotsConfiguration : IEntityTypeConfiguration<Slot>
	{
		public void Configure(EntityTypeBuilder<Slot> builder)
		{
			builder.ToTable("slot");

			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id).HasColumnName("id").IsRequired();
			builder.Property(s => s.Price).HasColumnName("price").IsRequired();
			builder.Property(s => s.StartDatediff).HasColumnName("datediff_start").IsRequired();
			builder.Property(s => s.FinishDatediff).HasColumnName("datediff_finish").IsRequired();
			builder.Property(s => s.Type).HasColumnName("type").IsRequired();
			builder.Property(s => s.HoursFrom).HasColumnName("hours_from").IsRequired();
			builder.Property(s => s.HoursTo).HasColumnName("hours_to").IsRequired();
			builder.Property(s => s.Name).HasColumnName("name").IsRequired();
			builder.Property(s => s.Description).HasColumnName("description").IsRequired();
			builder.Property(s => s.HoursToAccess).HasColumnName("hours_to_access");
			builder.Property(s => s.DaysOfWeek).HasColumnName("days_of_week").IsRequired();
		}
	}
}
