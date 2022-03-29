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
        Stopwatch stopwatch = new Stopwatch();

        bool StopwatchIsPressed = false;
        bool TimeSpanIsPressed = true;
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
                HorizontalOptions = LayoutOptions.Center,
                Text = "Включить Таймер."
                
            };

            timerButton.Clicked += TimerButtonClicked;

            stackLayout.Children.Add(labelTimer);
            stackLayout.Children.Add(timerButton);

            Content = stackLayout;

        }

        bool OnTimerTick()
        {
            labelTimer.Text = DateTime.Now.ToString();
            timerButton.Text = "Переключиться на Таймер.";
            return TimeSpanIsPressed;
        }

        bool OnStopWatchLaunch()
        {
            stopwatch.Start();
            TimeSpan ts = stopwatch.Elapsed;


            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            labelTimer.Text = elapsedTime;
            timerButton.Text = "Переключиться на дату и время.";

            return StopwatchIsPressed;
        }


        private void TimerButtonClicked(object seder, EventArgs e)
        {
            if (TimeSpanIsPressed == true && StopwatchIsPressed ==false)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(0.1), OnStopWatchLaunch);
                TimeSpanIsPressed = false;
                StopwatchIsPressed = true;
                stopwatch.Restart();
            }

            else if (TimeSpanIsPressed == false && StopwatchIsPressed == true)
            { 
                Device.StartTimer(TimeSpan.Zero, OnTimerTick);
                TimeSpanIsPressed = true;
                StopwatchIsPressed = false;
            }


            }
        }
    
    


}

