using DocumentFormat.OpenXml.Vml.Office;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Entry = DocumentFormat.OpenXml.Vml.Office.Entry;

namespace Spaceship
{
    public class ParkingHouse
    {
        Dictionary<string, Spaceship> parkingsLots = new Dictionary<string, Spaceship>();
        private object monthLabel;

        private ParkingHouse()
        {
            int[] parkingLots1 = new int[15];
            int[] parkingLots2 = new int[15];
            int[] parkingLots3 = new int[15];
            //parkingsPlaces.("A", new Spaceship[15]);
            //parkingsPlaces.Add("B", new Spaceship[15]);
            //parkingsPlaces.Add("C", new Spaceship[15]);
        }

        public string registerSpaceship()
        {


            //string input = string.Empty;
            //bool inputAccepted = true;

            //while (!inputAccepted)
            //{
            //    Console.Clear();
            //    Console.WriteLine($"Var vänlig och skriv in ett registreringsnummer i detta format: ABC123 eller ABC12A (I, Q, V, Å, Ä & Ö är inte acceptabelt)\n");
            //    input = Console.ReadLine().ToUpper().Trim();

            //    if (input.Length == 6
            //        && !input.Contains('Å')
            //        && !input.Contains('Ä')
            //        && !input.Contains('Ö')
            //        && !input.Contains('I')
            //        && !input.Contains('Q')
            //        && !input.Contains('V')
            //        )
            //    {
            //        if (
            //            Char.IsLetter(input[0])
            //            && Char.IsLetter(input[1])
            //            && Char.IsLetter(input[2])
            //            && Char.IsNumber(input[3])
            //            && Char.IsNumber(input[4])
            //            && (Char.IsNumber(input[5]) || Char.IsLetter(input[5]))
            //            )
            //        {
            //            Console.Clear();
            //            inputAccepted = true;
            //            return input;
            //        }
            //    }
            //}
            //Console.Clear();
            //return "";
        }

        public static int GetValidNumber(string info, int min, int max)
        {
            bool inputAccepted = false;
            int validNumber = min - 1;

            while (!inputAccepted || validNumber < min || validNumber > max)
            {
                Console.Clear();
                Console.WriteLine(info);
                Console.WriteLine($"\nEnter a number between {min} and {max}");
                inputAccepted = Int32.TryParse(Console.ReadLine().Trim(), out validNumber);
            }

            Console.Clear();
            return validNumber;
        }



        public static string GetValidString(string info)
        {
            string output = string.Empty;

            while (string.IsNullOrEmpty(output))
            {
                Console.WriteLine(info);
                output = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(output))
                {
                    Console.Clear();
                    Console.WriteLine("Input can not be empty.");
                }
                Console.Clear();
            }
            return output;
        }




        public static string GetValidString(string info, string console, params string[] choices)
        {
            bool inputAccepted = false;
            string output = "";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < choices.Length; i++)
            {
                stringBuilder.Append(choices[i] + "\n");
            }

            while (!inputAccepted)
            {
                Console.WriteLine(info + "\nVälj mellan dessa:\n");
                Console.WriteLine(stringBuilder.ToString());
                output = Console.ReadLine().Trim();

                for (int i = 0; i < choices.Length; i++)
                {
                    if (output.ToLower() == choices[i].ToLower())
                    {
                        inputAccepted = true;
                        Console.Clear();
                        return choices[i];
                    }
                }
                Console.Clear();
            }
            return output;
        }




        //    string regNumber = "ABC123";
        //    string parkNumber = "A01";
        //    string[] splits = parkNumber.Split("(?<=\\D)(?=\\d)");
        //    string tempNum = splits[1].replaceFirst("^0+(?!$)", "");
        //    int pnum = int.Parse(tempNum);
        //    Spaceship[] parkeringsPlacesInTheFloor = parkeringsPlaces.GetType(splits[0]);
        //    if (parkeringsPlacesInTheFloor[--pnum] == null)
        //    {
        //        Spaceship tempObj = new Spaceship(parkNumber, regNumber);
        //        parkeringsPlacesInTheFloor[pnum] = tempObj;
        //    }
        //    else
        //    {
        //        Console.WriteLine("This spot is already taken.");
        //    }
        //}

        //public void leaveParkingPlace()
        //{
        //    string regNumber = "ABC123";
        //    string parkNumber = "A01";
        //    string[] splits = parkNumber.Split("(?<=\\D)(?=\\d)");
        //    string tempNum = splits[1].replaceFirst("^0+(?!$)", "");
        //    int pnum = int.Parse(tempNum);
        //    Spaceship[] parkeringsPlacesInTheFloor = parkeringsPlaces.get(splits[0]);
        //    if (parkeringsPlacesInTheFloor[--pnum] != null)
        //    {
        //        Spaceship tempObj = parkeringsPlacesInTheFloor[pnum];
        //        if (tempObj.GetRegistreringsNumber().equals(regNumber))
        //        {
        //            int price = CalculateThePrice(tempObj);
        //            PrintInvoice(price);
        //            parkeringsPlacesInTheFloor[pnum] = null!;
        //        }

        //    }


        //}

        private int CalculateThePrice(Spaceship spaceship)
        {


            DateTime dateTime = new DateTime();
            DateTime date = dateTime;
            DateTime registerTime = spaceship.getTime();
            int price = 0;
            int registerDay = DateTime.Now.Year;
            int leavingDay = DateTime.Now.Year;
            int differensBetweenDays = leavingDay - registerDay;
            if (differensBetweenDays > 0)
            {
                price = differensBetweenDays * 50;
            }
            else
            {
                int registerHour = DateTime.Now.Hour;
                int leavingHour = DateTime.Now.Hour;
                int differensBetweenHours = leavingHour - registerHour;
                if (differensBetweenHours > 0)
                {
                    price = differensBetweenHours * 15;
                }
                else
                {
                    int registerMin = DateTime.Now.Minute;
                    int leavingMin = DateTime.Now.Minute;
                    int differensBetweenMinutes = leavingMin - registerMin;
                    price = differensBetweenMinutes * 5;
                }

            }
            return price;
        }

        private void PrintInvoice(int p)
        {
            Console.WriteLine("Thanks for your visiting.");
            Console.WriteLine("-----------------------");
            Console.WriteLine("The Amount Is: " + p);
        }

        public void ShowAllAvailableSpots(bool v)
        { //O(K) konstant. 3 * 15 = 45.

            //foreach (KeyValuePair<string, string> entry in parkeringsPlaces)
            //{
            //    string tempKey = entry.getKey();
            //    Spaceship[] tempValues = entry.getValue();
            //    for (int i = 0; i < tempValues.length; i++)
            //    {
            //        String tempStr = "";
            //        if (i < 9)
            //        {
            //            tempStr = "0";
            //        }
            //        if (tempValues[i] == null)
            //        {
            //            Console.WriteLine(tempKey + tempStr + (i + 1) + " ");
            //        }
            //    }
            //}
            //Directory Entry, Spaceship[] Entry parkingsLots.entrySet()
            //Dictionary<string, Spaceship> parkingsLots = new Dictionary<string, Spaceship>();
            for (Dictionary<Entry, Spaceship> parkingsLots)
            {
                string tempkey = Entry.getkey();
                Spaceship[] tempvalues = Entry.getvalue();
                for (int i = 0; i < tempvalues.Length; i++)
                {
                    string tempstr = "";
                    if (i < 9)
                    {
                        tempstr = "0";
                    }
                    if (tempvalues[i] == null)
                    {
                        Console.WriteLine(tempkey + tempstr + (i + 1) + " ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }

    
}
