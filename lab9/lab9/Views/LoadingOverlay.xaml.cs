namespace Lab9.Views;

public partial class LoadingOverlay : ContentView
{
    public LoadingOverlay()
    {
        InitializeComponent();
    }

    public async Task ShowAsync()
    {
        IsVisible = true;
        await this.FadeTo(1, 250, Easing.CubicInOut);
    }

    public async Task HideAsync()
    {
        await this.FadeTo(0, 250, Easing.CubicInOut);
        IsVisible = false;
    }
}
