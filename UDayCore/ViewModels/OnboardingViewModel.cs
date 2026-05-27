using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UDayCore.Models.Enums;

namespace UDayCore.ViewModels
{
    public partial class OnboardingViewModel : ObservableObject
    {
        [ObservableProperty] public partial string UserName { get; set; }

        public List<string> Shifts { get; } = new() { "Manhã", "Tarde", "Noite" };

        public IReadOnlyList<DayPeriod> Periods { get; } = Enum.GetValues<DayPeriod>();
        [ObservableProperty]  public partial DayPeriod SelectedPeriod { get; set; } = DayPeriod.Evening;

        public IReadOnlyList<SortOption> SortOptions { get; } = Enum.GetValues<SortOption>();

        [ObservableProperty] public partial SortOption SelectedSort { get; set; } = SortOption.Priority;

        [ObservableProperty] public partial bool ManageWeekends { get; set; } = false;

        public IReadOnlyList<AppTheme> Themes { get; } = Enum.GetValues<AppTheme>();
        [ObservableProperty] public partial AppTheme SelectedTheme { get; set; } = AppTheme.Light;

        partial void OnSelectedThemeChanged(AppTheme value)
        {
            if (Application.Current != null)  
                Application.Current.UserAppTheme = value;
        }

        [RelayCommand]
        private void FinishOnboarding()
        {
            // Se o usuário não digitar nome, colocamos um padrão carinhoso
            string finalName = string.IsNullOrWhiteSpace(UserName) ? "Pingo Fogo" : UserName;

            Preferences.Default.Set("IsFirstRun", false);
            Preferences.Default.Set("UserName", finalName);
            Preferences.Default.Set("ManageWeekends", ManageWeekends);
            Preferences.Default.Set("PreferredDayPeriod", (int)SelectedPeriod);
            Preferences.Default.Set("DefaultSort", (int)SelectedSort);
            Preferences.Default.Set("AppTheme", (int)SelectedTheme);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current?.Windows[0].Page = new AppShell();
            });
        }
    }
}
