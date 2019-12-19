using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
   

    public class Dog 
    {
        private bool isSleeping = false; 
    public Dog()
        {
            isSleeping = false; 
        }
        public bool IsSleeping
        {
            get
            {
                return isSleeping; 
            }
            private set
            {
                isSleeping = value; 
            }
          
        }
       public string MakeSound()
        {
            if (IsSleeping == true)
            {
                return "Zzzzz...";
            }
            else
            {
                return "Woof!"; 
            }
        }
        public void Sleep()
        {
           IsSleeping = true; 
        }
        public void WakeUp()
        {
           IsSleeping = false;
        }

    }
}
