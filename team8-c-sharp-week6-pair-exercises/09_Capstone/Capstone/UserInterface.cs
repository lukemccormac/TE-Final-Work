using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Capstone.Models;
using System.Linq;
using Capstone.DAL.VenueInfo;
using Capstone.DAL.CategoryInfo;
using Capstone.DAL.ReservationInfo;
using Capstone.DAL.SpaceInVenue;
using Capstone.DAL.StateInfo;
using Capstone.DAL.ReceiptInfo;
using System.Globalization;

namespace Capstone
{
    public class UserInterface
    {
        public UserInterface()
        {

        }

        private IStateDAO stateDAO;
        private ICategoryDAO categoryDAO;
        private IVenueDAO venueDAO;
        private IReservationDAO reservationDAO;
        private ISpaceDAO spaceDAO;
        private IReceiptDAO receiptDAO;
        private int venueSelection = 0;
        private string familyName = "";
        private string spaceName = "";
        private string venueName = "";
        private int groupSize = 0;
        private DateTime arrivalDate = new DateTime();
        private DateTime leaveDate = new DateTime();
        private decimal totalPrice = 0;

        public UserInterface(string connectionString)
        {
            this.categoryDAO = new CategorySQLDAO(connectionString);
            this.venueDAO = new VenueSQLDAO(connectionString);
            this.reservationDAO = new ReservationSQLDAO(connectionString);
            this.spaceDAO = new SpaceSQLDAO(connectionString);
            this.stateDAO = new StateSQLDAO(connectionString);
            this.receiptDAO = new ReceiptSQLDAO(connectionString);
        }


        public void Run()
        {
            PrintMainMenu();
        }
        public void PrintMainMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do ?");
                Console.WriteLine("1. List Venues");
                Console.WriteLine("Q. Quit");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        CaseOne();
                        break;


                    case "Q":
                        Quit();
                        break;

                    default:
                        Console.WriteLine("Invalid option selected");
                        break;
                }
                Console.WriteLine();
            }

        }
        private void CaseOne()
        {
            ViewVenues();
            Console.WriteLine();
            Console.WriteLine("Which venue would you like to view?");
            int selectionFromVenue = Convert.ToInt32(Console.ReadLine());
            VenueSelection(selectionFromVenue);
            VenuesDetails(venueSelection);
            Console.WriteLine();
            Console.WriteLine("What would you like to do next ?");
            VenueSpacesMenu(venueSelection);

        }
        private void Quit()
        {
            Console.WriteLine();
            Console.WriteLine("Have a great day!");
            Thread.Sleep(3000);
            Environment.Exit(1);
        }
        private void SubMenu()
        {

        }
        private void ViewVenues()
        {
            IList<Venue> venues = venueDAO.GetAllVenues();
            if (venues.Count > 0)
            {
                int count = 1;
                foreach (Venue ven in venues)
                {
                    Console.WriteLine(count + ") " + ven.Name);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("*** No Results***");
            }
        }

        private void VenuesDetails(int venueSelection)
        {

            if (venueSelection <= 15 && venueSelection >= 1)
            {
                Venue venue = venueDAO.GetVenue(venueSelection);
                Console.WriteLine();
                Console.WriteLine(venue.Name);
                LocationInfo(venueSelection);
                ListCategory(venueSelection);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(venue.Description);

            }
            else
                Console.WriteLine("Please Make Valid Selection");

        }

        private void VenueSpacesMenu(int venueSelection)
        {
            {
                while (true)
                {

                    Console.WriteLine("1) View Spaces");
                    Console.WriteLine("2) Search for Reservation");
                    Console.WriteLine("R) Return to Previous Selection");
                    string selection = Console.ReadLine();

                    switch (selection)
                    {
                        case "1":
                            ListVenueSpaces(venueSelection);

                            break;

                        case "2":
                            ReserveASpace();
                            break;
                        case "R":
                            return;
                    }
                    Console.WriteLine();
                }

            }
        }        
        private void VenueSelection(int selectionFromVenue)
        {
            IList<Venue> venues = venueDAO.GetAllVenues();
            venueSelection = venues[selectionFromVenue - 1].ID;
            venueName = venues[selectionFromVenue - 1].Name;

        }
        private void ListVenueSpaces(int venueSelection)
        {
            Console.WriteLine();
            Console.WriteLine("".PadRight(7)+"Name".PadRight(25)+ "Open".PadRight(10)+"Close".PadRight(12)+"Daily Rate".PadRight(20)+"Max Occupancy");
            IList<Space> spaces = spaceDAO.GetAllSpaces(venueSelection);
            if (spaces.Count > 0)
            {
                foreach (Space item in spaces)
                {
                    string openMonth = "";
                    string closeMonth = "";
                    if (item.OpenFrom != "")
                    {
                        openMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(item.OpenFrom));
                    }
                    if (item.OpenTo != "")
                    {
                        closeMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(item.OpenTo));
                    }
                    Console.WriteLine("#"+ item.ID.ToString().PadRight(5) + " " + item.Name.PadRight(25) + " " + openMonth.PadRight(10) + " " + closeMonth.PadRight(10) + " " + item.DailyRate.ToString("C").PadRight(20) + " " + item.MaxOccupancy);

                }
            }
            else
            {
                Console.WriteLine("*** No Results***");
            }

        }
        private void ListCategory(int venueSelection)
        {
            Console.WriteLine();
            Console.Write("Categories:");
            IList<Category> category = categoryDAO.GetAllCategories(venueSelection);
            if (category.Count > 0)
            {
                int count = 0;
                foreach (Category item in category)
                {
                    if (category.Count > count)
                    {
                        Console.Write(item.Name + ", ");
                        count++;
                    }
                    else
                    {
                        Console.Write(item.Name);
                    }
                }
            }
            else
            {
                Console.WriteLine("*** No Results***");
            }

        }

        private void ReserveASpace()
        {
           
            Console.Write("When do you need the space? ");
            DateTime start_date = Convert.ToDateTime(Console.ReadLine());
            arrivalDate = start_date;
            Console.Write("What is the last day you will need the space? ");
            DateTime end_date = Convert.ToDateTime(Console.ReadLine());
            leaveDate = end_date;
            Console.Write("How many people will be in attendance? ");
            int numberOfAttendees = int.Parse(Console.ReadLine());
            groupSize = numberOfAttendees;
            IList<Reservation> reservations = reservationDAO.CheckReservation(start_date, end_date, numberOfAttendees, venueSelection);
            Console.WriteLine("The following spaces are available based on your needs:");
            Console.WriteLine();
            Console.WriteLine(string.Format("{0, -10}{1, -28}{2, -20}{3,-20}", "Space #","Name", "Daily Rate" ,"Total Cost"));
            double totalCost = 0.00;
            foreach (Reservation item in reservations)
            {
                double days =((end_date - start_date).TotalDays);
                totalCost = days * Convert.ToDouble(item.DailyRate);
                totalPrice = (Decimal)totalCost;
                Console.WriteLine(string.Format("{0, -10}{1, -28}{2, -20}{3,-20}", item.SpaceID, item.VenueName, item.DailyRate.ToString("c"), totalCost.ToString("c")));
            }
            Console.WriteLine();
            Console.Write("Which space would you like to reserve(enter 0 to cancel) ?");
            int spaceNumber = Convert.ToInt32(Console.ReadLine());
            foreach(Reservation item in reservations)
            {
                if (item.SpaceID == spaceNumber)
                {
                    spaceName = item.VenueName;
                }
            }   
            if (spaceNumber == 0)
            {
                return;
            }
            Console.Write("Who is this reservation for?");
            familyName = Console.ReadLine();
            Console.WriteLine();
            Receipt receipt = receiptDAO.ReceiptWriter(spaceNumber, groupSize, arrivalDate, leaveDate,familyName);
            Console.WriteLine("Thanks for submitting your reservation!The details for your event are listed below:");
            Console.WriteLine();
            PrintReceipt(venueSelection, familyName, spaceName, venueName, groupSize, arrivalDate, leaveDate, totalPrice);


        }

        private void LocationInfo(int venueSelection)
        {
            State state = stateDAO.GetLocation(venueSelection);
            Console.Write("Location: ");
            Console.Write(state.Name + ", " + state.StateAbbreviation);


        }
        private void PrintReceipt(int venueSelection, string familyName, string spaceName, string venueName , int groupSize, DateTime arrivalDate, DateTime leaveDate, decimal totalPrice)
        {
            Random generator = new Random();
            String result = generator.Next(0, 99999999).ToString("D8");
            Console.WriteLine("ConfirmationNumber: "+ result);
            Console.WriteLine("Venue: " + venueName);
            Console.WriteLine("Space: " + spaceName);
            Console.WriteLine("Reserved For: " + familyName);
            Console.WriteLine("Attendees: " + groupSize);
            Console.WriteLine("Arrival Date: " + arrivalDate);
            Console.WriteLine("Depart Date: " + leaveDate);
            Console.WriteLine("Total Cost: " + totalPrice.ToString("c"));
        }

    }
}
