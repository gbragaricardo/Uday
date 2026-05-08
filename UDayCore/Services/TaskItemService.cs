using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Data;
using UDayCore.Models.Entities;

namespace UDayCore.Services
{
    public class TaskItemService
    {
        public async Task SaveTaskItemAsync(TaskItem newTask)
        {
            using var db = new UDayDbContext();

            db.TaskItems.Add(newTask);
            await db.SaveChangesAsync();

        }
    }
}
