using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Interfaces;
using UDayCore.Models.ValueObjects;

namespace UDayCore.Models.Common
{
    public static class TimeSlots
    {
        public static IReadOnlyList<ITimeSlot> DefaultSlots { get; } =
        [
            new TimeSlot("06_08", "06h - 08h", new TimeOnly(6, 0),  new TimeOnly(8, 0)),
            new TimeSlot("08_10", "08h - 10h", new TimeOnly(8, 0),  new TimeOnly(10, 0)),
            new TimeSlot("10_12", "10h - 12h", new TimeOnly(10, 0), new TimeOnly(12, 0)),
            new TimeSlot("12_14", "12h - 14h", new TimeOnly(12, 0), new TimeOnly(14, 0)),
            new TimeSlot("14_16", "14h - 16h", new TimeOnly(14, 0), new TimeOnly(16, 0)),
            new TimeSlot("16_18", "16h - 18h", new TimeOnly(16, 0), new TimeOnly(18, 0)),
            new TimeSlot("18_20", "18h - 20h", new TimeOnly(18, 0), new TimeOnly(20, 0)),
            new TimeSlot("20_22", "20h - 22h", new TimeOnly(20, 0), new TimeOnly(22, 0)),
            new TimeSlot("22_00", "22h - 00h", new TimeOnly(22, 0), new TimeOnly(0, 0))
        ];
    }
}
