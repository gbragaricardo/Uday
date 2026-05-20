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
                // Aqui você avalia qual é a regra de tempo que a tarefa possui
                switch (Task.ScheduleType)
                {
                    case TaskScheduleType.TimeFrame:
                        // Exemplo: "14:00 - 15:30"
                        return $"{Task.AvailableFrom:hh\\:mm} - {Task.DueDate:hh\\:mm}";

                    case TaskScheduleType.TimeBox:
                        // Exemplo: "14:00 - 15:30"
                        return $"{Task.AvailableFrom:hh\\:mm} - {Task.DueDate:hh\\:mm}";

                    case TaskScheduleType.SpecificDate:
                        if (Task.DueDate == DateTime.Today)
                            return "Hoje";

                        //if (Task.DueDate.Date == DateTime.Today.AddDays(1))
                        //    return "Amanhã";

                        // Exemplo: "15 de Mai"
                        return $"{Task.DueDate:hh\\:mm}";

                    default:
                        return "Sem prazo";
                }
            }
        }

        public TaskItemWrapper(TaskItem task)
        {
            Task = task;

            switch (task.EffortLevel)
            {
                case EffortLevel.Light: DayPeriod = DayPeriod.Morning; break;

                case EffortLevel.Medium: DayPeriod = DayPeriod.Afternoon; break;

                case EffortLevel.Heavy: DayPeriod = DayPeriod.Evening; break;

                default: DayPeriod = DayPeriod.None; break;
            }
        }
    }
}
