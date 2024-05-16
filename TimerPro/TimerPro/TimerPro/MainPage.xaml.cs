using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimerPro.Custom;

namespace TimerPro
{
    public partial class MainPage : ContentPage
    {
        TimerLogic oTimerLogic;
        bool isRunning;

        public MainPage()
        {
            InitializeComponent();
            oTimerLogic = new TimerLogic();
        }

        void Start_Clicked(System.Object sender, System.EventArgs e)
        {
            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;
            isRunning = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if(isRunning)
                {
                    oTimerLogic.SetTickCount();
                    lblDisplay.Text = oTimerLogic.GetFormatedString();
                }
                
                return isRunning;
            } );

        }

        void Stop_Clicked(System.Object sender, System.EventArgs e)
        {
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            isRunning = false;
        }

        void Reset_Clicked(System.Object sender, System.EventArgs e)
        {
            oTimerLogic.Reset();
            lblDisplay.Text = oTimerLogic.GetFormatedString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            lblDisplay.Text = "00:00:00";
        }
    }
}

