using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum RecurrenceType
    {
        None,

        [Description("Diário")]
        Daily,

        [Description("Semanal")]
        Weekly,

        [Description("Mensal")]
        Monthly,

        [Description("Anual")]
        Yearly
    }
}
