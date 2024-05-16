using System;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Text;
using ShoppingList.Models;

namespace ShoppingList.Views
{
    public partial class NewAccountPage : ContentPage
	{	
		public NewAccountPage ()
		{
			InitializeComponent ();
			Title = "Create Account";
		}

        async void CreateUser_Clicked(System.Object sender, System.EventArgs e)
        {
			var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPass.Text, txtEmail.Text));
			var client = new HttpClient();
            var response = await client.PostAsync(new Uri("http://joewetzel.com/fvtc/account/createuser"), new StringContent(data, Encoding.UTF8, "application/json"));
			var AccountStatus = response.Content.ReadAsStringAsync().Result;

            //user exists
            //email exists
			//complete

			if (AccountStatus == "user exists")
			{
				await DisplayAlert("Error", "Sorry this username already exists", "Ok");
				return;

			}

            if (AccountStatus == "email exists")
            {
                await DisplayAlert("Error", "Sorry this email already exists", "Ok");
                return;

            }

            if (AccountStatus == "complete")
			{

				response = await client.PostAsync(new Uri("http://joewetzel.com/fvtc/account/login"), new StringContent(data, Encoding.UTF8, "application/json"));
                var SKey = response.Content.ReadAsStringAsync().Result;

				if (!string.IsNullOrEmpty(SKey))
				{
                    App.SessionKey = SKey;
					await Navigation.PopModalAsync();
                }
				else
				{
                    await DisplayAlert("Error", "Sorry there was an error Loggin in", "Ok");
                    return;

                }

            }
			else
			{
                await DisplayAlert("Error", "Sorry there was an error creating  account", "Ok");
                return;
            }

			
        }
    }
}

