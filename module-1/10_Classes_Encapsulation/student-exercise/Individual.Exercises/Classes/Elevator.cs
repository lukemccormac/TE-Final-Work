using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
       public int CurrentLevel { get { return currentLevel; } private set { } }
       public int NumberOfLevels { get;  }
       public bool DoorIsOpen { get; private set; }

    public Elevator (int numberOfLevels)
        {
          NumberOfLevels = numberOfLevels;
        }
        int currentLevel = 1; 
    public void OpenDoor()
        {
            DoorIsOpen = true; 
        }
    public void CloseDoor()
        {
            DoorIsOpen = false; 
        }
    public void GoUp(int desiredFloor)
        {
            if (DoorIsOpen == false && desiredFloor < NumberOfLevels)
            {
                CurrentLevel++; 
            }
        }
    public void GoDown(int desiredFloor)
        {
            if (DoorIsOpen == false && desiredFloor < NumberOfLevels)
            {
                CurrentLevel--;
            }
        }
    }
}
