using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Interfaces;

namespace UDayCore.Models.ValueObjects
{
    public class TimeSlot : ITimeSlot
    {
        public string Id { get; private set; } = string.Empty;
        public string DisplayName { get; private set; } = string.Empty;
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }

        public TimeSlot(string id, string displayName, TimeOnly start, TimeOnly end)
        {
            Id = id;
            DisplayName = displayName;
            StartTime = start;
            EndTime = end;
        }
    }
}
