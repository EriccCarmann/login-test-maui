namespace LoginTestAppMaui.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();

        var mapControl = new Mapsui.UI.Maui.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Content = mapControl;
    }
}