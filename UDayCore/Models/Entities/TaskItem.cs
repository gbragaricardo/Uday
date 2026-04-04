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
        public int EstimatedDurationMinutes { get; set; }
        public EnergyLevel EnergyLevel { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool IsRecurring { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
