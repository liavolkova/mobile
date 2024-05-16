﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingList.Models;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ShoppingList.Views
{	
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
			Title = "Login";
		}

        void Create_Clicked(System.Object sender, System.EventArgs e)
        {
			Navigation.PushAsync(new NewAccountPage());
        }

        async void Login_Clicked(System.Object sender, System.EventArgs e)
        {
            var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPass.Text, null));
            var client = new HttpClient();
            var response = await client.PostAsync(new Uri("http://joewetzel.com/fvtc/account/login"), new StringContent(data, Encoding.UTF8, "application/json"));

            var SKey = response.Content.ReadAsStringAsync().Result;

            if (!string.IsNullOrEmpty(SKey))
            {
                App.SessionKey = SKey;
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Sorry your username and password don't match", "Ok");
                return;

            }

        }
    }
}

