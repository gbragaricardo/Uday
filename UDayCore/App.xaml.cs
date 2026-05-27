using Microsoft.Extensions.DependencyInjection;
using UDayCore.Views;

namespace UDayCore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Preferences.Default.Set("IsFirstRun", true);

            bool isFirstRun = Preferences.Default.Get("IsFirstRun", true);

            Page initialPage = isFirstRun ? new OnboardingPage() : new AppShell();

            return new Window(initialPage);
        }
    }
}