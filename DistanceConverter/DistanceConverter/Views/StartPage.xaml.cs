namespace DistanceConverter.Views;

public partial class StartPage : ContentPage
{
    double KeyValue = 0;

    double dbl_m2f = 3.280839895;
    double dbl_m2i = 39.37007874;
    double dbl_m2mi = 0.00062137119;
    double dbl_m2m = 1;
    double dbl_m2nm = 0.0005399568034557;
    double dbl_m2y = 1.093613298;
    double dbl_m2k = 0.001;

    public StartPage()
	{
		InitializeComponent();
		Title = "Distance Converter";

		ToolbarItem tbi = new ToolbarItem();
		tbi.Text = "About";
		
		this.ToolbarItems.Add(tbi);

		tbi.Clicked += delegate
		{
			Navigation.PushAsync(new AboutPage());
		};
    }

    void Clear_Clicked(System.Object sender, System.EventArgs e)
    {
        txtMeters.Text = "";
        txtInches.Text = "";
        txtFeet.Text = "";
        txtYards.Text = "";
        txtMiles.Text = "";
        txtNautical.Text = "";
        txtKilometers.Text = "";
    }

    void Convert_Clicked (System.Object sender, System.EventArgs e)
    {
        txtMeters.Text = (KeyValue * dbl_m2m).ToString("g9");
        txtInches.Text = (KeyValue * dbl_m2i).ToString("g9");
        txtFeet.Text = (KeyValue * dbl_m2f).ToString("g9");
        txtYards.Text = (KeyValue * dbl_m2y).ToString("g9");
        txtMiles.Text = (KeyValue * dbl_m2mi).ToString("g9");
        txtNautical.Text = (KeyValue * dbl_m2nm).ToString("g9");
        txtKilometers.Text = (KeyValue * dbl_m2k).ToString("g9");
    }

    void txtMeters_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        //m2m
        double dblNumber;
        bool isValid = double.TryParse(txtMeters.Text, out dblNumber);
        if(isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2m;
        } else
        {
            KeyValue = 0;
        }
    }

    void txtInches_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        double dblNumber;
        bool isValid = double.TryParse(txtInches.Text, out dblNumber);
        if (isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2i;
        }
        else
        {
            KeyValue = 0;
        }
    }

    void txtFeet_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        double dblNumber;
        bool isValid = double.TryParse(txtFeet.Text, out dblNumber);
        if (isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2f;
        }
        else
        {
            KeyValue = 0;
        }
    }

    void txtYards_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        double dblNumber;
        bool isValid = double.TryParse(txtYards.Text, out dblNumber);
        if (isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2y;
        }
        else
        {
            KeyValue = 0;
        }
    }

    void txtMiles_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        double dblNumber;
        bool isValid = double.TryParse(txtMiles.Text, out dblNumber);
        if (isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2mi;
        }
        else
        {
            KeyValue = 0;
        }
    }

    void txtNautical_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        double dblNumber;
        bool isValid = double.TryParse(txtNautical.Text, out dblNumber);
        if (isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2nm;
        }
        else
        {
            KeyValue = 0;
        }
    }

    void txtKilometers_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        double dblNumber;
        bool isValid = double.TryParse(txtKilometers.Text, out dblNumber);
        if (isValid && dblNumber != 0)
        {
            KeyValue = dblNumber / dbl_m2k;
        }
        else
        {
            KeyValue = 0;
        }
    }
}
