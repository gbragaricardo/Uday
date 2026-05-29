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
            var taskItems = await db.TaskItems.ToListAsync();
            
            return taskItems;
        }
        public async Task UpdateTaskItemAsync(TaskItem taskItem)
        {
            using var db = new UDayDbContext();
            
            db.TaskItems.Update(taskItem);
            await db.SaveChangesAsync();
        }

        public async Task DeleteTaskItemAsync(TaskItem taskItem)
        {
            using var db = new UDayDbContext();

            var entityToDelete = await db.TaskItems.FindAsync(taskItem.Id);
            if (entityToDelete != null)
            {
                db.TaskItems.Remove(entityToDelete);
                await db.SaveChangesAsync();
            }
        }
    }
}
