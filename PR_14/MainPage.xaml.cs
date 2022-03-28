using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace PR_14
{
    public partial class MainPage : ContentPage
    {
        StackLayout stackLayout = new StackLayout();
        Button timerButton;
        Label labelTimer;
        Stopwatch stopwatch;

        bool isPressed = false;

        public MainPage()
        {
            InitializeComponent();

            labelTimer = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
            };

            timerButton = new Button
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };

            timerButton.Clicked += TimerButtonClicked;

            stackLayout.Children.Add(labelTimer);
            stackLayout.Children.Add(timerButton);

            Content = stackLayout;

        }

        bool OnTimerTick()
        {
            labelTimer.Text = DateTime.Now.ToString();
            return isPressed;
        }

        bool OnStopWatchLaunch()
        {
            stopwatch.Start();
            TimeSpan ts = stopwatch.Elapsed;


            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            labelTimer.Text = elapsedTime;

            return isPressed;
        }


        private void TimerButtonClicked(object seder, EventArgs e)
        {
            if (isPressed == false)
            {
                Device.StartTimer(TimeSpan.Zero, OnTimerTick);
                isPressed = true;
            }

            else
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(0.1), OnStopWatchLaunch);
                isPressed = false;
            }


            }
        }
    
    


}

