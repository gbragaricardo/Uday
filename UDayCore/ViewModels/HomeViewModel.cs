using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UDayCore.Models.Entities;
using UDayCore.Models.Enums;

namespace UDayCore.ViewModels
{
    internal class HomeViewModel : ObservableObject
    {
        public ObservableCollection<TaskItem> MockTasks { get; set; } = [];

        public HomeViewModel()
        {
            MockTasks.Add(new TaskItem
            {
                Id = 1,
                Title = "Validar requisitos do Plugin Revit",
                EstimatedDurationMinutes = 90,
                DueDate = DateTime.Now,
                Priority = PriorityLevel.High,
                EffortLevel = EffortLevel.Heavy
            });

            MockTasks.Add(new TaskItem
            {
                Id = 2,
                Title = "Finalizar tela de audiências Angular",
                EstimatedDurationMinutes = 120,
                DueDate = DateTime.Now,
                Priority = PriorityLevel.Medium,
                EffortLevel = EffortLevel.Medium
            });

        }
    }
}
