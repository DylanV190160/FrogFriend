using System;
using System.Collections.Generic;
using System.Text;
using FrogFriend.Objects;

namespace FrogFriend.Objects
{

    public class TimeKeeper
    {
        /* String containing the property key */
        const string startTimeKey = "startTime";
        const string storedTimeKey = "storedTime";

        /* DateTime var used to store the start date value */

        public DateTime StartTime
        {
            get
            {
                /* Check if date value has been set*/
                if (App.Current.Properties.ContainsKey(startTimeKey))
                {
                    return new DateTime((long)App.Current.Properties[startTimeKey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            set
            {
                App.Current.Properties[startTimeKey] = value.Ticks;
            }
        }
        /* DateTime var used to store the date value */
        public DateTime StoredTime
        {
            get
            {
                /* Check if date value has been set */
                if (App.Current.Properties.ContainsKey(storedTimeKey))
                {
                    return new DateTime((long)App.Current.Properties[storedTimeKey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            set
            {
                App.Current.Properties[storedTimeKey] = value.Ticks;
            }
        }
        public TimeKeeper()
        {

        }

        public double GetTimeElapsed()
        {
            return (StoredTime - StartTime).TotalSeconds;
        }
    }
}
