using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Entities;
using UDayCore.Models.Enums;

namespace UDayCore.ViewModels.Items
{
    public partial class TaskItemWrapper : ObservableObject
    {
        public TaskItem Task { get; }

        [ObservableProperty] public partial bool IsAwaitingFeedback { get; set; }
        [ObservableProperty] public partial bool IsCheckBoxChecked { get; set; }
        [ObservableProperty] public partial bool IsCompleted { get; set; }
        [ObservableProperty] public partial DayPeriod DayPeriod { get; set; }

        public string DisplayTime
        {
            get
            {
                switch (Task.ScheduleType)
                {
                    case TaskScheduleType.TimeFrame:
                    case TaskScheduleType.TimeBox:
                        // Exibe o intervalo de dias: "12/05 - 18/05"
                        if (Task.AvailableFrom.HasValue && Task.DueDate.HasValue)
                            return $"{Task.AvailableFrom:dd/MM} - {Task.DueDate:dd/MM}";
                        
                        return "Período indefinido";

                    case TaskScheduleType.SpecificDate:
                        if (!Task.DueDate.HasValue) return "Data indefinida";

                        var date = Task.DueDate.Value.Date;
                        var today = DateTime.Today;

                        if (date == today)
                            return "Hoje";
                        
                        if (date == today.AddDays(1))
                            return "Amanhã";

                        // Para outras datas, mostra dd/MM
                        return $"{Task.DueDate:dd/MM}";

                    case TaskScheduleType.Recurring:
                        return Task.RecurrenceType switch
                        {
                            RecurrenceType.Daily => "Diariamente",
                            RecurrenceType.Weekly => "Semanalmente",
                            RecurrenceType.Monthly => "Mensalmente",
                            RecurrenceType.Yearly => "Anualmente",
                            _ => "Recorrente"
                        };

                    default:
                        return "Qualquer momento";
                }
            }
        }

        public TaskItemWrapper(TaskItem task)
        {
            Task = task;
            IsCompleted = task.IsCompleted;
            IsCheckBoxChecked = task.IsCompleted;

            switch (task.EffortLevel)
            {
                case EffortLevel.Light: DayPeriod = DayPeriod.Morning; break;

                case EffortLevel.Medium: DayPeriod = DayPeriod.Afternoon; break;

                case EffortLevel.Heavy: DayPeriod = DayPeriod.Evening; break;
            }
        }

        partial void OnIsCompletedChanged(bool value)
        {
            Task.IsCompleted = value;
        }
    }
}
