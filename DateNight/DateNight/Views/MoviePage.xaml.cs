namespace DateNight.Views;

public partial class MoviePage : ContentPage
{
	public MoviePage()
	{
		InitializeComponent();
        Title = "Going For Movie";
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        
        App.dateCalc.MovieCost = txtMovie.Text;
    }
}
