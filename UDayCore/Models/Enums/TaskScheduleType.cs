using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum TaskScheduleType
    {
        [Description("Dia Específico")]
        SpecificDate,

        [Description("Período Predefinido")]
        TimeBox,

        [Description("Dia Inicial e Final")]
        TimeFrame,

        [Description("Recorrente")]
        Recurring
    }
}
