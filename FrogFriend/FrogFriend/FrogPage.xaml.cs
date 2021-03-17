using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrogFriend.Objects;
using FrogFriend;
using System.Timers;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrogFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrogPage : ContentPage
    {
        /* Create an instance of the frog object */

        private Frog frog = new Frog();

        void updateUI()
        {
            int frogXp = frog.Xp;

            if (frogXp < 1)
            {
                levelLabel.Text = "Neglected";
                xpLabel.Text = "Tap the food to feed frog";
            }
            else
            {
                levelLabel.Text = "Level 0" + Levels.GetLevelFromXp(frogXp).ToString();
                xpLabel.Text = frogXp.ToString();
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                frogImage.Source = "frog_" + frog.CurrentFrogState + "_" + (Levels.GetLevelFromXp(frogXp) + 1).ToString();

                if (frog.CurrentFrogState == FrogState.sick)
                {
                    FrogDead();
                }
            });
        }


        public FrogPage()
        {
            InitializeComponent();

            updateUI();
            StartTimer();
        }

        void feedFrogTapped(System.Object sender, System.EventArgs e)
        {
            ResetTimer();

            frog.giveFood();

            updateUI();
        }

        private async void FrogDead()
        {
            await DisplayAlert("Dead", "Your pet frog has died!!", "New Frog");

            frog.Xp = 0;
            frog.CurrentFrogState = FrogState.healthy;
            ResetTimer();

            updateUI();
        }

        /* Create an instance of the timekeeper object */
        private TimeKeeper timeKeeper = new TimeKeeper();

        /* Create a timer */
        private static Timer timer;

      
        /* Timer Events */
        private void StartTimer()
        {
            timer = new Timer();

            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += UpdateTimedData;
            timer.Start();
        }

        private void ResetTimer()
        {
            timeKeeper.StartTime = DateTime.Now;

            StartTimer();
        }

        private void UpdateTimedData(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeElapsed = e.SignalTime - timeKeeper.StartTime;

            FrogState newFrogState = frog.CurrentFrogState;

            if (timeElapsed.TotalSeconds < 10)
            {
                newFrogState = FrogState.healthy;
            }
            else if (timeElapsed.TotalSeconds < 20)
            {
                newFrogState = FrogState.nothealthy;
            }
            else if (timeElapsed.TotalSeconds >= 20)
            {
                newFrogState = FrogState.sick;
            }
            if (newFrogState != frog.CurrentFrogState)
            {
                frog.CurrentFrogState = newFrogState;
                updateUI();
            }
        }
    }
}