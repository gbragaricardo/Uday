using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum TimeBoxType
    {
        [Description("Esta Semana")]
        ThisWeek,

        [Description("Próxima Semana")]
        NextWeek,

        [Description("Este Mês")]
        ThisMonth,

        [Description("Próximo Mês")]
        NextMonth
    }
}
