using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant
{
    public class Display: Restaurant
    {
        public static void ShowEventList()
        {
            Console.Write("Lista czasów eventow :");
            foreach (var Event in eventList)
            {
                Console.Write(Event.ExecuteTime + " ");
            }

            Console.WriteLine();
        }
        public static int ShowPplInQueue(List<Customer> customers)
        {
            int numberOfPpl = 0;
            foreach (var unused in customers)
                numberOfPpl++;
            return numberOfPpl;
        }
        public static int ShowPplInTables()
        {
            int numberOfPpl = 0;
            foreach (var o in tables)
            {
                if(o.Customer != null)
                    numberOfPpl++;
            }
            return numberOfPpl;
        }
        public static int ShowPplInBuffet(Buffet buffet)
        {
            int numberOfPpl = 0;
            foreach (var o in buffet.ListOfCustomers)
            {
                if (o != null)
                    numberOfPpl += o.NumberOfPeople;
            }
            return numberOfPpl;
        }
        public static int ShowPplInCashiers()
        {
            int numberOfPpl = 0;
            foreach (var o in cashiers)
            {
                if (o.Customer != null)
                    numberOfPpl++;
            }
            return numberOfPpl;
        }

    }
}
