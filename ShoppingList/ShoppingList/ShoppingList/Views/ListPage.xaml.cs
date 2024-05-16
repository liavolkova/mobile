using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ShoppingList.Models;
using Xamarin.Forms;
using static ShoppingList.Models.UserData;

namespace ShoppingList.Views
{	
	public partial class ListPage : ContentPage
	{	
		public ListPage ()
		{
			InitializeComponent ();
            lstData.Refreshing += LstData_Refreshing; 
		}
        protected void LstData_Refreshing (object sender, EventArgs e)
        {
            LoadData();
            lstData.IsRefreshing = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (string.IsNullOrEmpty(App.SessionKey))
			{
				Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
			}
			else
			{
                //txtInput.Text = App.SessionKey;
                LoadData();
			}
        }

        async void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            var data = JsonConvert.SerializeObject(new UserAccount(App.SessionKey));
            var client = new HttpClient();
            var response = await client.PostAsync(new Uri("http://joewetzel.com/fvtc/account/logout"), new StringContent(data, Encoding.UTF8, "application/json"));

            var SKey = response.Content.ReadAsStringAsync().Result;


            App.SessionKey = string.Empty;
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));

        }

        async void AddData_Clicked(System.Object sender, System.EventArgs e)
        {
            var data = JsonConvert.SerializeObject(new UserData(null,txtInput.Text,App.SessionKey));
            var client = new HttpClient();
            var response = await client.PostAsync(new Uri("http://joewetzel.com/fvtc/account/data"), new StringContent(data, Encoding.UTF8, "application/json"));
            txtInput.Text = string.Empty;
            LoadData();
        }

        async public void LoadData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://joewetzel.com/fvtc/account/data/" + App.SessionKey);
            var wsJson = response.Content.ReadAsStringAsync().Result;

            var UserDataObj = JsonConvert.DeserializeObject<UserDataCollection>(wsJson);
            lstData.ItemsSource = UserDataObj.UserDataItems;

        }

        async void DeleteItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var mi = (MenuItem)sender;
            var dataID = mi.CommandParameter.ToString();

            
            var data = JsonConvert.SerializeObject(new UserData(dataID, null, App.SessionKey));
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://joewetzel.com/fvtc/account/data"),
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };
            await client.SendAsync(request);
            LoadData();
        }
    }
}

