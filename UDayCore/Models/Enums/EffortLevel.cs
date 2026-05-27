using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum EffortLevel
    {
        [Description("Leve")]
        Light,

        [Description("Médio")]
        Medium,

        [Description("Pesado")]
        Heavy
    }
}
