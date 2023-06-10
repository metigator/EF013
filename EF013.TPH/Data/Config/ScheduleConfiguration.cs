﻿using EF013.TPH.Entities;
using EF013.TPH.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF013.TPH.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(x => x.Title)
                .HasConversion(
                     x => x.ToString(),
                     x => (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), x)
                );

            builder.ToTable("Schedules");
        }
    }
}
