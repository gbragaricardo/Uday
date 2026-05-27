using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UDayCore.Models.Enums
{
    public enum SortOption
    {
        [Description("Prioridade (Mais Urgente)")]
        Priority,

        [Description("Esfoço (Mais pesado)")]
        Effort
    }
}
