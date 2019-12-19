using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; }
        public int CurrentChannel { get; private set; }
        public int CurrentVolume { get; private set; }
        public Television()
        {
            IsOn = false;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }
        public void TurnOff()
        {
            IsOn = false;
        }
        public void TurnOn()
        {
            IsOn = true;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }
        public void ChangeChannel(int newChannel)
        {
            if (IsOn == true && newChannel <= 18 && newChannel >= 3)
            {
                CurrentChannel = newChannel;
            }
        }
        public void ChannelUp()
        {
            if (IsOn == true && CurrentChannel >= 3 && CurrentChannel < 18)
            {
                CurrentChannel++;
            }
            else
            {
                CurrentChannel = 3;
            }
        }
        public void ChannelDown()
        {
            if (IsOn == true && CurrentChannel <= 18 && CurrentChannel > 3)
            {
                CurrentChannel--;
            }
            else
            {
                CurrentChannel = 3;
            }
        }
        public void RaiseVolume()
        {
            if (IsOn == true && CurrentVolume >= 1 && CurrentVolume < 10)
            {
                CurrentVolume++;
            }
        }
        public void LowerVolume()
        {
            if (IsOn == true && CurrentVolume >= 1 && CurrentVolume <= 10)
            {
                CurrentVolume--;
            }
        }
    }
}


