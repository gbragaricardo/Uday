using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using UDayCore.Models.Common;
using UDayCore.Models.Entities;
using UDayCore.Models.Interfaces;
using UDayCore.Models.ValueObjects;

namespace UDayCore.ViewModels
{
    // Classe auxiliar para a tela: une o horário e a nota atual do Slider
    public class TimeSlotEntry
    {
        public ITimeSlot Slot { get; set; }
        public int Score { get; set; } = 5; // Nota padrão começa no meio (5)
    }

    public class DailyLogViewModel
    {
        // Exibe a data de hoje formatada (ex: 14 de abril)
        public string CurrentDateText => DateTime.Now.ToString("dd 'de' MMMM");

        // A lista que vai aparecer na tela
        public ObservableCollection<TimeSlotEntry> LogEntries { get; set; } = new();

        // O comando que o botão "Salvar" vai executar
        public ICommand SaveCommand { get; }

        public DailyLogViewModel()
        {
            // 1. Carrega todos os horários do seu TimeSlots.DefaultSlots
            foreach (var slot in TimeSlots.DefaultSlots)
            {
                LogEntries.Add(new TimeSlotEntry { Slot = slot });
            }

            // 2. Prepara a ação de salvar
            SaveCommand = new Command(SaveLog);
        }

        private void SaveLog()
        {
            // Cria um novo registro usando o seu Model Entity
            var newLog = new DailyLog
            {
                Date = DateTime.Now.Date,
                Notes = "Log gerado via tela"
            };

            // Varre a lista da tela e converte para o formato do banco
            foreach (var entry in LogEntries)
            {
                newLog.TimeSlotScores.Add(new TimeSlotScore
                {
                    TimeSlotId = entry.Slot.Id,
                    Score = entry.Score
                });
            }

        }
    }
}
