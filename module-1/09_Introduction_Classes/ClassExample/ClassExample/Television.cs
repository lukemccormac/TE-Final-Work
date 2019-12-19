using System;
using System.Collections.Generic;
using System.Text;

namespace ClassExample
{
    class Television
    {
        private string serialNumber = "";
        private int screenSize = 0;
        private bool hasCaPbWarning = false;

        public string SerialNumber
        {
            get
            {

                return serialNumber;
            }
            set
            {
                serialNumber = value;
            }
        }

        public int Voltage { get; set; }

        public string Marketplace
        {
            get
            {
                if (Voltage == 110 || Voltage == 0)
                {
                    return "US";

                }
                else
                {
                    return "Europe";
                }
            }
        }

        public Television(int screenSize)
        {
            this.screenSize = screenSize;
        }
        public Television()
        {
            this.screenSize = 32;
        }


        public bool SetCaPbWarning(bool input)
        {
            hasCaPbWarning = input;
            return hasCaPbWarning;
        }

        public bool SetScreenSize (int screenSize)
        {
            if(true)
            {
                this.screenSize = screenSize;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
