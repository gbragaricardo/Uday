using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Entities;

namespace UDayCore.ViewModels.Items
{
    public partial class TaskItemWrapper : ObservableObject
    {
        public TaskItem Task { get; }

        [ObservableProperty] public partial bool IsAwaitingFeedback { get; set; }
        [ObservableProperty] public partial bool IsCheckBoxChecked { get; set; }
        [ObservableProperty] public partial bool IsCompleted { get; set; }

        public string DisplayTime
        {
            get
            {
                // Aqui você avalia qual é a regra de tempo que a tarefa possui
                switch (Task.TimeType)
                {
                    case TimeType.Timebox:
                        // Exemplo: "14:00 - 15:30"
                        return $"{Task.StartTime:hh\\:mm} - {Task.EndTime:hh\\:mm}";

                    case TimeType.Timeframe:
                        // Exemplo: "Manhã", "Tarde", "Noite"
                        return Task.Period.ToString();

                    case TimeType.SpecificDate:
                        // Uma lógica bacana para datas específicas
                        if (Task.DueDate.Date == DateTime.Today)
                            return "Hoje";
                        if (Task.DueDate.Date == DateTime.Today.AddDays(1))
                            return "Amanhã";

                        // Exemplo: "15 de Mai"
                        return Task.DueDate.ToString("dd 'de' MMM");

                    default:
                        return "Sem prazo";
                }
            }
        }

        public TaskItemWrapper(TaskItem task)
        {
            Task = task;
        }
    }
}
