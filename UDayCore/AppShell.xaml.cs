using UDayCore.Views;

namespace UDayCore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreateTaskPage), typeof(CreateTaskPage));
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
        }
    }
}
