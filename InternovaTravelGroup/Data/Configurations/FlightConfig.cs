using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Question_7_API.Data.Entities;

namespace Question_7_API.Data.Configurations
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("tb_flight");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.FlightID);
            builder.Property(t => t.MealTypeID);
            builder.Property(t => t.FlightTypeID);
            builder.Property(t => t.FlightNumber);
            builder.Property(t => t.PassengerName);
        }
    }
}
