using System;
using Restaurant.Time;

namespace Restaurant.Conditional
{
    public class ManagerServe : Restaurant
    {
        public static bool Realize()
        {
            if (tableQueue.Count != 0 && manager.Customer == null)
            {
                foreach (var customer in tableQueue)
                {
                    foreach (var table in tables)
                    {
                        if (table.Customer == null && table.Seats >= customer.NumberOfPeople)
                        {
                            table.Customer = customer;
                            manager.Customer = customer;
                            foreach (var customer2 in tableQueue)
                            {
                                if (customer2.Id == customer.Id)
                                {
                                    tableQueue.Remove(customer2);
                                    break;
                                }
                            }
                            var ev = new ManagerEnd(waiterQueue, manager, clock, S);
                            Event.PutEvents(ev, eventList);
                            Console.WriteLine("Obsługa przez kierownika");
                            Display.ShowEventList();
                            return true;
                        }
                    }
                }
            }

            return false;
        } 
    }
}
