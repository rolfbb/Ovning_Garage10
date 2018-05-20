using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
{
    class MessageHandler
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
        }

        internal static string GetLang()
        {
            return lang;
        }

        internal static string message(string key)
        {
            var msgDict = GetDictionary();

            string msg;
            try
            {
                msg = msgDict[key];
            }
            catch (KeyNotFoundException)
            {
                msg = String.Format($"Message for key {key} not found!");
                UI.WriteLine(msg);
            }
            return msg;
        }

        private static Dictionary<string, string> GetDictionary()
        {
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
            try
            {
                switch (lang)
                {
                    case "LANG":
                        //Console.WriteLine("InitMessages - LANG");
                        InitMessagesLang();
                        break;
                    case "SE":
                        //Console.WriteLine("InitMessages - SE");
                        InitMessagesSE();
                        break;
                    case "EN":
                        //Console.WriteLine("InitMessages - EN");
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

            // Menu
            Add(dict, "menuSeparator", "============================================================================");
            Add(dict, "langMenuHeader", "Garage - Select language");

            // Commands
            Add(dict, "S", "Svenska");
            Add(dict, "E", "Engelska");

            // Error messages
            Add(dict, "notDefinedMessage", "<not defined>");
            Add(dict, "nonExistingCommand", "The command '{0}' does not exist!");
            Add(dict, "readAndExecuteCommandFailure", "The command '{0}' caused a failure!\n'{1}'");

        }

        private static void InitMessagesSE()
        {
            // Generic name
            var dict = msgDictSE;

            // Dictionary id
            dict.Add("DICT", "msgDictSE");

            // Menu
            Add(dict, "menuSeparator", "============================================================================");
            Add(dict, "mainMenuHeader", "*         Garage - Huvudmeny");

            // Commands
            Add(dict, "L", "Lista samtliga parkerade fordon");
            Add(dict, "T", "Lista fordonstyper och hur många av varje som står i garaget");
            Add(dict, "A", "Lägg till fordon");
            Add(dict, "R", "Ta bort fordon");
            Add(dict, "S", "Sök fordon via registreringsnumret");
            Add(dict, "C", "Skapa nytt garage");
            Add(dict, "F", "Antal lediga parkeringsplatser");
            Add(dict, "M", "Huvudmeny");
            Add(dict, "Q", "Avsluta programmet");

            // Error messages
            Add(dict, "notDefinedMessage", "<ej definierat>");
            Add(dict, "nonExistingCommand", "Kommando '{0}' finns ej!");
            Add(dict, "readAndExecuteCommandFailure", "Kommando '{0}' orsakade ett fel!\n'{1}'");

            // Vechicles
            Add(dict, "Airplane", "Flygplan");
            Add(dict, "Car", "Bil");
            Add(dict, "Bus", "Buss");
            Add(dict, "Motorcycle", "Motorcykel");
            Add(dict, "Boat", "Båt");

            // Questions
            Add(dict, "nbrSpaces", "Ange antal parkeringslatser för det nya garaget: ");
            Add(dict, "ColorMsg", "Färg: ");
            Add(dict, "LengthMsg", "Längd: ");
            Add(dict, "NbrOfWheelsMsg", "Antal hjul: ");
            Add(dict, "NbrOfSeatsMsg", "Antal sittplatser: ");

            // Entity properties
			Add(dict, "Color", "Färg");
			Add(dict, "Length", "Längd");
			Add(dict, "NbrOfWheels", "Antal hjul");
			Add(dict, "NbrOfSeats", "Antal säten");

            // Messages
            Add(dict, "noGarageAddNew", "Det finns inget garage - ett nytt garage behöver skapas.");
            Add(dict, "newGarageCreated", "Nytt garage med {0} är skapat.");
            Add(dict, "nbrFreeSpaces", "Antal lediga parkeringsplatser");
            Add(dict, "vehicleIsParked", "Fordonet är parkerat. Det finns {0} platser kvar.");
            Add(dict, "noFreeSpaces", "Det går inte att parkera; det finns {0} platser kvar.");
            Add(dict, "onlyNumbersIsAllowed", "Du får bara använda siffror i svaret. Du skrev: \"{0}\".");
            Add(dict, "vehicleColonLabel", "Fordon: ");

        }

        private static void InitMessagesEN()
        {
            // Generic name
            var dict = msgDictEN;

            // Dictionary id
            Add(dict, "DICT", "msgDictEN");

            // Menu
            Add(dict, "menuSeparator", "============================================================================");
            Add(dict, "mainMenuHeader", "*         Garage - Main Menu");

            // Commands
            Add(dict, "L", "List parked vehicles");
            Add(dict, "T", "List types and quantity of vechicles in the garage");
            Add(dict, "A", "Add vehicle");
            Add(dict, "R", "Remove vehicle");
            Add(dict, "S", "Search for vehicle on reg no");
            Add(dict, "C", "Create new garage");
            Add(dict, "F", "Number of free parking spaces");
            Add(dict, "M", "Main menu");
            Add(dict, "Q", "Exit program");

            // Error messages
            Add(dict, "notDefinedMessage", "<not defined>");
            Add(dict, "nonExistingCommand", "The command '{0}' does not exist!");
            Add(dict, "readAndExecuteCommandFailure", "The command '{0}' caused a failure!\n'{1}'");

            // Vechicles
            Add(dict, "Airplane", "Airplane");
            Add(dict, "Car", "Car");
            Add(dict, "Bus", "Bus");
            Add(dict, "Motorcycle", "Motorcycle");
            Add(dict, "Boat", "Boat");

            // Questions
            Add(dict, "nbrSpaces", "Enter number of parkings spaces for the new garage: ");
            Add(dict, "ColorMsg", "Color: ");
            Add(dict, "LengthMsg", "Length: ");
            Add(dict, "NbrOfWheelsMsg", "Number of wheels: ");
            Add(dict, "NbrOfSeatsMsg", "Number of seats: ");

            // Entity properties
            Add(dict, "Color", "Color");
            Add(dict, "Length", "Length");
            Add(dict, "NbrOfWheels", "Number Of Wheels");
            Add(dict, "NbrOfSeats", "Number of seats");

            // Messages
            Add(dict, "noGarageAddNew", "There's no garage - a new will be created.");
            Add(dict, "newGarageCreated", "A new garage with {0} parking spaces is created.");
            Add(dict, "nbrFreeSpaces", "Number of free parking spaces");
            Add(dict, "vehicleIsParked", "The vehicle is parked. There are {0} parking spaces left.");
            Add(dict, "noFreeSpaces", "It is not possible to park now; there are {0} parking spaces left.");
            Add(dict, "onlyNumbersIsAllowed", "You may only use numbers in the answer. You wrote: \"{0}\".");
            Add(dict, "vehicleColonLabel", "Vehicle: ");

        }
    }
}
