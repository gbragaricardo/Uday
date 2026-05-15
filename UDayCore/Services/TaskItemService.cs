using Microsoft.EntityFrameworkCore;
using UDayCore.Data;
using UDayCore.Models.Entities;
using UDayCore.ViewModels.Items;

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

        public async Task<IList<TaskItem>> GetTaskItemsAsync()
        {
            using var db = new UDayDbContext();
            var taskItems = await db.TaskItems.AsNoTracking().ToListAsync();
            
            return taskItems;
        }
        public async Task DeleteTaskItemAsync(TaskItem taskItem)
        {
            using var db = new UDayDbContext();
            var taskItems = await db.TaskItems.ToListAsync();
            taskItems.Remove(taskItem);

            await db.SaveChangesAsync();
        }
    }
}
