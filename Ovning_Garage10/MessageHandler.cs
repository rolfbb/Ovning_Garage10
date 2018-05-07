using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
{
    class Msg
    {
        ////How to use custom format when storing 'custom format string':
        //// https://stackoverflow.com/questions/29844514/string-format-variable-in-composite-string-format?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        //string str = "{{0:{0}}}";
        //string format = string.Format(str, "yyyy");
        //format = string.Format(format, DateTime.Now);
        //Console.WriteLine(format);
        //Console.WriteLine("Kommando '{0}' finns ej!", "F");

        private static string lang;
        private static Dictionary<string, string> msgDictLANG = new Dictionary<string, string>();
        private static Dictionary<string, string> msgDictSE = new Dictionary<string, string>();
        private static Dictionary<string, string> msgDictEN = new Dictionary<string, string>();

        internal static void SetLang(string language)
        {
            lang = language;
            UI.WriteLine("Language is set to: " + lang);
        }

        internal static string message(string key)
        {
            //Console.WriteLine($"Msg lang: {lang}, key: {key}");
            var msgDict = GetDictionary();

            string msg;
            try
            {
                msg = msgDict[key];
            }
            catch (KeyNotFoundException)
            {
                msg = String.Format($"Message for key {key} ({lang}) not found!");
                UI.WriteLine(msg);
            }
            return msg;
        }

        private static Dictionary<string, string> GetDictionary()
        {
            //Console.WriteLine("GetDictionary...lang: " + lang);
            var msgDict = msgDictEN;
            switch (lang)
            {
                case "LANG":
                    msgDict = msgDictLANG;
                    break;
                case "SE":
                    msgDict = msgDictSE;
                    break;
                case "EN":
                    msgDict = msgDictEN;
                    break;
            }

            return msgDict;
        }

        internal static void InitMessages()
        {
            //Console.WriteLine("InitMessages, lang: " + lang);
            try
            {
                switch (lang)
                {
                    case "LANG":
                        Console.WriteLine("InitMessages - LANG");
                        InitMessagesLang();
                        break;
                    case "SE":
                        Console.WriteLine("InitMessages - SE");
                        InitMessagesSE();
                        break;
                    case "EN":
                        Console.WriteLine("InitMessages - EN");
                        InitMessagesEN();
                        break;
                }
            }
            catch (ArgumentException e)
            {
                UI.WriteLine($"Error in InitMessages ({lang}): {e.Message}");
            }
        }

        private static void Add(Dictionary<string, string> dict, string key, string message)
        {
            try
            {
                dict.Add(key, message);
            }
            catch (ArgumentException e)
            {
                UI.WriteLine(String.Format($"Error in InitMessages, dict: {dict["DICT"]} ({lang}): {e.Message}"));
            }
        }

        private static void InitMessagesLang()
        {
            // Generic name
            var dict = msgDictLANG;

            // Dictionary id
           Add(dict, "DICT", "msgDictLANG");

            // Commands
           Add(dict, "S", "Svenska");
           Add(dict, "E", "Engelska");

           Add(dict, "langMenuHeader", "Garage - Select language");
           Add(dict, "notDefinedMessage", "<not defined>");
           Add(dict, "nonExistingCommand", "Kommando '{0}' finns ej!");
        }

        private static void InitMessagesSE()
        {
            // Generic name
            var dict = msgDictSE;

            // Dictionary id
            dict.Add("DICT", "msgDictSE");

            // Commands
            Add(dict, "F", "Listar samtliga parkerade fordon");
            Add(dict, "T", "Listar fordonstyper och hur många av varje som står i garaget");
            Add(dict, "L", "Lägg till fordon");
            Add(dict, "R", "Ta bort fordon");
            Add(dict, "S", "Sök fordon via registreringsnumret");
            Add(dict, "C", "Skapa nytt garage");
            Add(dict, "G", "Antal lediga parkeringsplatser");
            Add(dict, "M", "Huvudmeny");
            Add(dict, "Q", "Du har valt att avsluta programmet");

            // Vechicles
            Add(dict, "Airplane", "Flygplan");
            Add(dict, "Car", "Bil");
            Add(dict, "Bus", "Buss");
            Add(dict, "Motorcycle", "Motorcykel");
            Add(dict, "Boat", "Båt");

            // Questions
            Add(dict, "nbrParkingSpots", "Ange antal parkeringslatser för det nya garaget: ");

            // Messages
            Add(dict, "noGarage", "Det finns inget garage - ett nytt garage behöver skapas.");
            Add(dict, "nonExistingCommand", "Kommando '{0}' finns ej!");
            Add(dict, "newGarageCreated", "Nytt garage med {0} är skapat.");
            Add(dict, "nbrFreeSpots", "Antal lediga parkeringsplatser");
            Add(dict, "vehicleIsParked", "Fordonet är parkerat. Det finns {0} platser kvar.");
            Add(dict, "noFreeSpots", "Det går inte att parkera; det finns {0} platser kvar.");
            Add(dict, "onlyNumbersIsAllowed", "Du får bara använda siffror i svaret. Du skrev: \"{0}\".");
            Add(dict, "vehicleColon", "Fordon: ");
            Add(dict, "mainMenuHeader", "*         Garage - Huvudmeny");
            Add(dict, "notDefinedMessage", "<inte angivet>");

        }

        //private static void InitMessagesLang()
        //{
        //    // Dictionary id
        //    msgDictLANG.Add("DICT", "msgDictLANG");

        //    // Commands
        //    msgDictLANG.Add("S", "Svenska");
        //    msgDictLANG.Add("E", "Engelska");

        //    msgDictLANG.Add("langMenuHeader", "Garage - Select language");
        //    msgDictLANG.Add("notDefinedMessage", "<not defined>");
        //    msgDictLANG.Add("nonExistingCommand", "Kommando '{0}' finns ej!");
        //}

        //private static void InitMessagesSE()
        //{
        //    // Dictionary id
        //    msgDictSE.Add("DICT", "msgDictSE");

        //    // Commands
        //    msgDictSE.Add("F", "Listar samtliga parkerade fordon");
        //    msgDictSE.Add("T", "Listar fordonstyper och hur många av varje som står i garaget");
        //    msgDictSE.Add("L", "Lägg till fordon");
        //    msgDictSE.Add("R", "Ta bort fordon");
        //    msgDictSE.Add("S", "Sök fordon via registreringsnumret");
        //    msgDictSE.Add("C", "Skapa nytt garage");
        //    msgDictSE.Add("G", "Antal lediga parkeringsplatser");
        //    msgDictSE.Add("M", "Huvudmeny");
        //    msgDictSE.Add("Q", "Du har valt att avsluta programmet");

        //    // Vechicles
        //    msgDictSE.Add("Airplane", "Flygplan");
        //    msgDictSE.Add("Car", "Bil");
        //    msgDictSE.Add("Bus", "Buss");
        //    msgDictSE.Add("Motorcycle", "Motorcykel");
        //    msgDictSE.Add("Boat", "Båt");

        //    // Questions
        //    msgDictSE.Add("nbrParkingSpots", "Ange antal parkeringslatser för det nya garaget´: ");

        //    // Messages
        //    msgDictSE.Add("noGarage", "Det finns inget garage - ett nytt garage behöver skapas.");
        //    msgDictSE.Add("nonExistingCommand", "Kommando '{0}' finns ej!");
        //    msgDictSE.Add("newGarageCreated", "Nytt garage med {0} är skapat.");
        //    msgDictSE.Add("nbrFreeSpots", "Antal lediga parkeringsplatser");
        //    msgDictSE.Add("vehicleIsParked", "Fordonet är parkerat. Det finns {0} platser kvar.");
        //    msgDictSE.Add("noFreeSpots", "Det går inte att parkera; det finns {0} platser kvar.");
        //    msgDictSE.Add("onlyNumbersIsAllowed", "Du får bara använda siffror i svaret. Du skrev: \"{0}\".");
        //    msgDictSE.Add("vehicleColon", "Fordon: ");
        //    msgDictSE.Add("mainMenuHeader", "*         Garage - Huvudmeny");
        //    msgDictSE.Add("notDefinedMessage", "<inte angivet>");

        //}
        private static void InitMessagesEN()
        {
            // Generic name
            var dict = msgDictEN;

            // Dictionary id
            Add(dict, "DICT", "msgDictEN");
            
            // Commands
            Add(dict, "F", "Listing parked vehicles");
            Add(dict, "T", "Listing types and quantity of vechicles in the garage");
            Add(dict, "L", "Add vehicle");
            Add(dict, "R", "Remove vehicle");
            Add(dict, "S", "Search for vehicle on reg no");
            Add(dict, "C", "Create new garage");
            Add(dict, "G", "Number of free parking spots");
            Add(dict, "M", "Main menu");
            Add(dict, "Q", "You have chosen to exit from the program");

            // Vechicles
            Add(dict, "Airplane", "Airplane");
            Add(dict, "Car", "Car");
            Add(dict, "Bus", "Bus");
            Add(dict, "Motorcycle", "Motorcycle");
            Add(dict, "Boat", "Boat");

            // Questions
            Add(dict, "nbrParkingSpots", "Enter number of parkings spots for the new garage: ");

            // Messages
            Add(dict, "noGarage", "There's no garage - a new will be created.");
            Add(dict, "nonExistingCommand", "Command '{0}' is not found!");
            Add(dict, "newGarageCreated", "A new garage with {0} parking spots is created.");
            Add(dict, "nbrFreeSpots", "Number of free parking spots");
            Add(dict, "vehicleIsParked", "The vehicle is parked. There are {0} parking spots left.");
            Add(dict, "noFreeSpots", "It is not possible to park now; there are {0} parking spots left.");
            Add(dict, "onlyNumbersIsAllowed", "You may only use numbers in the answer. You wrote: \"{0}\".");
            Add(dict, "vehicleColon", "Vehicle: ");
            Add(dict, "mainMenuHeader", "*         Garage - Main Menu");
            Add(dict, "notDefinedMessage", "<not defined>");

        }
    }
}
