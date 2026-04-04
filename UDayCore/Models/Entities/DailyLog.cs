using System;
using System.Collections.Generic;
using System.Text;

namespace UDayCore.Models.Entities
{
    public class DailyLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public int Score06_08 { get; set; }
        public int Score08_10 { get; set; }
        public int Score10_12 { get; set; }
        public int Score14_16 { get; set; }
        public int Score16_18 { get; set; }
        public int Score18_20 { get; set; }
        public int Score20_22 { get; set; }

        public string Notes { get; set; } = string.Empty;
    }
}
