using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Marathon.Models;
using Newtonsoft.Json;

namespace Marathon
{
    public partial class MainPage : ContentPage
    {
        RaceCollection RaceObj;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FillPicker();
        }

        private void FillPicker()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://joewetzel.com/fvtc/marathon/");
            var response = client.GetAsync("races/").Result;
            var wsJson =  response.Content.ReadAsStringAsync().Result;

            RaceObj = JsonConvert.DeserializeObject<RaceCollection>(wsJson);
            RacePicker.ItemsSource = RaceObj.races;
        }

        void RacePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var SelectedRace = ((Picker)sender).SelectedIndex;
            var RaceID = RaceObj.races[SelectedRace].id;

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://joewetzel.com/fvtc/marathon/");
            var response = client.GetAsync("results/" + RaceID ).Result;
            var wsJson = response.Content.ReadAsStringAsync().Result;

            var ResultsObj = JsonConvert.DeserializeObject<ResultsCollection>(wsJson);

            var CellTemplate = new DataTemplate(typeof(TextCell));
            CellTemplate.SetBinding(TextCell.TextProperty, "name");
            CellTemplate.SetBinding(TextCell.DetailProperty, "detail");
            ResultListView.ItemTemplate = CellTemplate;

            ResultListView.ItemsSource = ResultsObj.results;
        }
    }
}

