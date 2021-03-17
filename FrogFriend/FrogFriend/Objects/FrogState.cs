using System;
using System.Collections.Generic;
using System.Text;

namespace FrogFriend.Objects
{

    public enum FrogState
    {
        healthy,
        nothealthy,
        sick
    }
    class FrogStates
    {
        public static string GetFrogString(FrogState frogState)
        {
            switch (frogState)
            {
                case FrogState.healthy:
                    return "healthy";
                case FrogState.nothealthy:
                    return "not healthy";
                case FrogState.sick:
                    return "sick";
                default:
                    return "Croaking";
            }
        }

        public static FrogState GetFrogState(string frogString)
        {
            switch (frogString)
            {
                case "healthy":
                    return FrogState.healthy;
                case "not healthy":
                    return FrogState.nothealthy;
                case "sick":
                    return FrogState.sick;
                default:
                    return FrogState.healthy;
            }
        }
    }
}
