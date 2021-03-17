using System;
using System.Collections.Generic;
using System.Text;

namespace FrogFriend.Objects
{
    public class Frog
    {
        /* String containing the property key */
        const string frogStateKey = "frogState";
        const string frogXpKey = "frogXp";
        const string frogNameKey = "frogName";

        /* String used to store the state of the frog */
        public FrogState CurrentFrogState
        {
            get
            {
                /* Check if date value has been set */
                if (App.Current.Properties.ContainsKey(frogStateKey))
                {
                    return FrogStates.GetFrogState((string)App.Current.Properties[frogStateKey]);
                }
                else
                {
                    return FrogState.healthy;
                }
            }
            set
            {
                App.Current.Properties[frogStateKey] = FrogStates.GetFrogString(value);
            }
        }

        /* Int used to store the xp of the plant */
        public int Xp
        {
            get
            {
                /* Check if date value has been set */
                if (App.Current.Properties.ContainsKey(frogXpKey))
                {
                    Console.WriteLine((int)App.Current.Properties[frogXpKey]);
                    return (int)App.Current.Properties[frogXpKey];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                App.Current.Properties[frogXpKey] = value;
            }
        }

        public Frog()
        {

        }

        public void giveFood()
        {
            Xp = Xp + 500;
        }
    }
}
