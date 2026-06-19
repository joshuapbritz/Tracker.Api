using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Domain.Events;

namespace Tracker.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(p => p.EventName).HasColumnName("event_name").HasMaxLength(200).IsRequired();
            builder.Property(p => p.EventSource).HasColumnName("event_source").HasMaxLength(200).IsRequired();
            builder.Property(p => p.EventTimestamp).HasColumnName("event_timestamp").IsRequired();
        }
    }
}
