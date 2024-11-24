using Microcharts;
using SkiaSharp;
using Lab9.Models;
using Lab9.Services;

namespace Lab9.Views;

public partial class ChartsPage : ContentPage
{
    private readonly IBankApi _api;

    public Chart Chart { get; set; }

    public ChartsPage(IBankApi api)
    {
        InitializeComponent();
        _api = api;
        LoadChart();
    }

    private async void LoadChart()
    {
        var banks = await _api.GetBanksAsync();
        var entries = banks.Select(b => new Microcharts.Entry(b.BankId)
        {
            Label = b.BankName,
            ValueLabel = b.BankId.ToString(),
            Color = SKColor.Parse("#3498db")
        }).ToList();

        Chart = new BarChart { Entries = entries };
        OnPropertyChanged(nameof(Chart));
    }
}
