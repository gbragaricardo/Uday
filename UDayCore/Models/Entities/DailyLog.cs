using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.ValueObjects;

namespace UDayCore.Models.Entities
{
    public class DailyLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; } 
        public List<TimeSlotScore> TimeSlotScores { get; set; } = [];
        public string Notes { get; set; } = string.Empty;
        public DailyLog()
        {
            DayOfWeek = Date.DayOfWeek;
        }
    }
}
