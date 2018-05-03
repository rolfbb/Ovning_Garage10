using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
{
    class Msg
    {
        internal static Dictionary<string, string> msgDict = new Dictionary<string, string>();

        internal static string message(string key)
        {
            string msg;
            try
            {
                msg = msgDict[key];
            }
            catch (KeyNotFoundException)
            {
                msg = "<not defined>";
            }
            return msg;
        }

        internal static void InitMessages()
        {
            // Commands
            msgDict.Add("F","Listar samtliga parkerade fordon");
            msgDict.Add("T","Listar fordonstyper och hur många av varje som står i garaget");
            msgDict.Add("L","Lägg till fordon");
            msgDict.Add("R","Ta bort fordon");
            msgDict.Add("S","Sök fordon via registreringsnumret");
            msgDict.Add("C","Skapa nytt garage");
            msgDict.Add("G","Antal lediga parkeringsplatser");
            msgDict.Add("M","Huvudmeny");
            msgDict.Add("Q", "Du har valt att avsluta programmet");

            // Vechicles
            msgDict.Add("Airplane", "Flygplan");
            msgDict.Add("Car", "Bil");
            msgDict.Add("Bus", "Buss");
            msgDict.Add("Motorcycle", "Motorcykel");
            msgDict.Add("Boat", "Båt");

            // Questions

            // Messages
        }
    }
}
