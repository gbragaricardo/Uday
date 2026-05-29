using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum PriorityLevel
    {
        [Description("Baixa")]
        Low,

        [Description("Média")]
        Medium,

        [Description("Alta")]
        High
    }
}
