using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Entities;
using UDayCore.Models.Enums;

namespace UDayCore.Data.Mappings
{
    internal class TaskItemMap : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(t => t.Description)
                   .HasMaxLength(500);

            builder.Property(t => t.EstimatedDurationMinutes)
                   .HasDefaultValue(15)
                   .IsRequired();

            builder.Property(t => t.AvailableFrom)
                   .IsRequired(false);

            builder.Property(t => t.DueDate)
                   .IsRequired(false);

            builder.Property(t => t.Priority)
                   .HasConversion<string>()
                   .HasDefaultValue(PriorityLevel.Medium)
                   .IsRequired();

            builder.Property(t => t.EffortLevel)
                   .HasConversion<string>()
                   .HasDefaultValue(EffortLevel.Medium)
                   .IsRequired();

            builder.Property(t => t.RecurrenceType)
                   .HasConversion<string>()
                   .HasDefaultValue(RecurrenceType.None)
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP")
                   .IsRequired();

            builder.Property(t => t.IsCompleted)
                   .HasDefaultValue(false)
                   .IsRequired();
        }
    }
}
