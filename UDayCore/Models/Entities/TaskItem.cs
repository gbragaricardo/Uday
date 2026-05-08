using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Enums;

namespace UDayCore.Models.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EstimatedDurationMinutes { get; set; } = 15;
        public DateTime? AvailableFrom { get; set; }
        public DateTime? DueDate { get; set; }
        public EffortLevel EffortLevel { get; set; } = EffortLevel.Medium;
        public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
        public RecurrenceType RecurrenceType { get; set; } = RecurrenceType.None;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;
    }
}
