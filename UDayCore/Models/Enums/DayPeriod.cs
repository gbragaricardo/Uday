using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum DayPeriod
    {
        None = 0,

        [Description("Manhã")]
        Morning = 1,

        [Description("Tarde")]
        Afternoon = 2,

        [Description("Noite")]
        Evening = 3    
    }
}
