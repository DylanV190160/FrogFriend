using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FrogFriend.Objects;

namespace FrogFriend
{
    public partial class App : Application
    {

        /* Create an instance of the timekeeper object */
        private TimeKeeper timeKeeper = new TimeKeeper();
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart");
            /* Get the current system time from the timekeeper object */

            Console.WriteLine(timeKeeper.StoredTime);
            Console.WriteLine(timeKeeper.GetTimeElapsed());
        }

        protected override void OnSleep()
        {
            Console.WriteLine("OnSleep");
            /* Save the current system time to the timekeeper object */

            timeKeeper.StoredTime = DateTime.Now;
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume");
            /* Get the current system time from the timekeeper object */

            Console.WriteLine(timeKeeper.StoredTime);
            Console.WriteLine(timeKeeper.GetTimeElapsed());
        }
    }
}
