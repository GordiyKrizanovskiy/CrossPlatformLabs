using Lab9.Services;
using Lab9.Models;

namespace Lab9.Views;

public partial class BanksPage : ContentPage
{
    private readonly IBankApi _api;

    public List<Bank> Banks { get; set; } = new();

    public BanksPage(IBankApi api)
    {
        InitializeComponent();
        _api = api;
        LoadData();
    }

    private async void LoadData()
    {
        await Loading.ShowAsync();
        try
        {
            Banks = await _api.GetBanksAsync();
            OnPropertyChanged(nameof(Banks));
        }
        finally
        {
            await Loading.HideAsync();
        }
    }

}
