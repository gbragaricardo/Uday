using System;
using System.Collections.Generic;
using System.Text;

namespace UDayCore.Models.Interfaces
{
    public interface ITimeSlot
    {
        string Id { get; }
        string DisplayName { get; }
        TimeOnly StartTime { get; }
        TimeOnly EndTime { get; }
    }
}
