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
            //Console.WriteLine("Language is set to: " + lang);
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
                msg = String.Format("Message for key {0} not found!", key);
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

        private static void InitMessagesLang()
        {
            // Commands
            msgDictLANG.Add("S", "Svenska");
            msgDictLANG.Add("E", "Engelska");

            msgDictLANG.Add("langMenuHeader", "Garage - Select language");
            msgDictLANG.Add("notDefinedMessage", "<not defined>");
        }

        private static void InitMessagesSE()
        {
            // Commands
            msgDictSE.Add("F", "Listar samtliga parkerade fordon");
            msgDictSE.Add("T", "Listar fordonstyper och hur många av varje som står i garaget");
            msgDictSE.Add("L", "Lägg till fordon");
            msgDictSE.Add("R", "Ta bort fordon");
            msgDictSE.Add("S", "Sök fordon via registreringsnumret");
            msgDictSE.Add("C", "Skapa nytt garage");
            msgDictSE.Add("G", "Antal lediga parkeringsplatser");
            msgDictSE.Add("M", "Huvudmeny");
            msgDictSE.Add("Q", "Du har valt att avsluta programmet");

            // Vechicles
            msgDictSE.Add("Airplane", "Flygplan");
            msgDictSE.Add("Car", "Bil");
            msgDictSE.Add("Bus", "Buss");
            msgDictSE.Add("Motorcycle", "Motorcykel");
            msgDictSE.Add("Boat", "Båt");

            // Questions
            msgDictSE.Add("nbrParkingSpots", "Ange antal parkeringslatser för det nya garaget´: ");

            // Messages
            msgDictSE.Add("noGarage", "Det finns inget garage - ett nytt garage behöver skapas.");
            msgDictSE.Add("nonExistingCommand", "Kommando '{0}' finns ej!");
            msgDictSE.Add("newGarageCreated", "Nytt garage med {0} är skapat.");
            msgDictSE.Add("nbrFreeSpots", "Antal lediga parkeringsplatser");
            msgDictSE.Add("vehicleIsParked", "Fordonet är parkerat. Det finns {0} platser kvar.");
            msgDictSE.Add("noFreeSpots", "Det går inte att parkera; det finns {0} platser kvar.");
            msgDictSE.Add("onlyNumbersIsAllowed", "Du får bara använda siffror i svaret. Du skrev: \"{0}\".");
            msgDictSE.Add("vechicleColon", "Fordon: ");
            msgDictSE.Add("mainMenuHeader", "*         Garage - Huvudmeny");
            msgDictSE.Add("notDefinedMessage", "<inte angivet>");

        }

        private static void InitMessagesEN()
        {
            // Commands
            msgDictEN.Add("F", "Listing parked vehicles");
            msgDictEN.Add("T", "Listing types and quantity of vechicles in the garage");
            msgDictEN.Add("L", "Add vehicle");
            msgDictEN.Add("R", "Remove vehicle");
            msgDictEN.Add("S", "Search for vehicle on reg no");
            msgDictEN.Add("C", "Create new garage");
            msgDictEN.Add("G", "Number of free parking spots");
            msgDictEN.Add("M", "Main menu");
            msgDictEN.Add("Q", "You have chosen to exit from the program");

            // Vechicles
            msgDictEN.Add("Airplane", "Airplane");
            msgDictEN.Add("Car", "Car");
            msgDictEN.Add("Bus", "Bus");
            msgDictEN.Add("Motorcycle", "Motorcycle");
            msgDictEN.Add("Boat", "Boat");

            // Questions
            msgDictEN.Add("nbrParkingSpots", "Enter number of parkings spots for the new garage: ");

            // Messages
            msgDictEN.Add("noGarage", "There's no garage - a new will be created.");
            msgDictEN.Add("nonExistingCommand", "Command '{0}' is not found!");
            msgDictEN.Add("newGarageCreated", "A new garage with {0} parking spots is created.");
            msgDictEN.Add("nbrFreeSpots", "Number of free parking spots");
            msgDictEN.Add("vehicleIsParked", "The vehicle is parked. There are {0} parking spots left.");
            msgDictEN.Add("noFreeSpots", "It is not possible to park now; there are {0} parking spots left.");
            msgDictEN.Add("onlyNumbersIsAllowed", "You may only use numbers in the answer. You wrote: \"{0}\".");
            msgDictEN.Add("vechicleColon", "Vehicle: ");
            msgDictEN.Add("mainMenuHeader", "*         Garage - Main Menu");
            msgDictEN.Add("notDefinedMessage", "<not defined>");

        }
    }
}
