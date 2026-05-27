using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Enums;

namespace UDayCore.Models.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeOnly WakeUpTime { get; set; }
        public TimeOnly SleepTime { get; set; }
        public DayPeriod PreferredDayPeriod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<string> ActiveTimeSlotIds { get; set; } = [];
    }
}
