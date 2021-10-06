using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant
{
    public class AlarmDelete : Restaurant
    {
        private const double PercentageOfGuestsLeave = 0.3;
        public static void DeleteFromQueue()
        {
            DeleteFromLists(tableQueue);
            DeleteFromLists(buffetQueue);
            DeleteFromLists(buffets.ListOfCustomers);
            DeleteFromLists(cashierQueue);

            foreach (var T in cashiers)
            {
                if (T.Customer != null)
                {
                    if (Generators.UniformDistribution() <= PercentageOfGuestsLeave)
                    {
                        DeleteFromEventList(T.Customer);
                        T.Customer = null;
                        Console.WriteLine("WYPIERDALA");
                    }
                }
            }
            foreach (var T in tables)
            {
                if (T.Customer != null)
                {
                    if (Generators.UniformDistribution() <= PercentageOfGuestsLeave)
                    {
                        DeleteFromEventList(T.Customer);
                        Waiter Waiter = (waiters.Find(x => x.Customer == T.Customer));
                        if (Waiter != null)
                            Waiter.Customer = null;
                        Customer Customer = waiterQueue.Find(x => x == T.Customer);
                        if (Customer != null)
                            waiterQueue.Remove(Customer);
                        if (T.Customer == manager.Customer)
                            manager.Customer = null;
                        T.Customer = null;
                        Console.WriteLine("WYPIERDALA");
                    }
                }
            }
        }

        private static void DeleteFromLists(List<Customer> customers)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (Generators.UniformDistribution() <= PercentageOfGuestsLeave)
                {
                    DeleteFromEventList(customers[i]);
                    customers.RemoveAt(i);
                    Console.WriteLine("WYPIERDALA");
                }
            }

        }

        private static void DeleteFromEventList(Customer customer)
        {
            foreach (var Event in eventList)
            {
                if (Event.Customer == customer)
                {
                    eventList.Remove(Event);
                    break;
                }
            }
        }
    }
}
