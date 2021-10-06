using System;
using Restaurant.Objects;
using Restaurant.Time;

namespace Restaurant.Conditional
{
    public class WaiterOrder : Restaurant
    {
        public static bool Realize()
        {
            if(waiterQueue.Count != 0)
            {
                foreach (var waiter in waiters)
                {
                    if (waiter.Customer == null)
                    {
                        waiter.Customer = waiterQueue[0];
                        waiterQueue.RemoveAt(0);
                        Table table = tables.Find(x => x.Customer == waiter.Customer);
                        if (waiter.Customer.FoodServe)
                        {
                            var ev = new WaiterFoodEnd(eventList, waiter.Customer, waiter, table, cashierQueue, clock, Generators.ExponentialDistribution(2000));
                            Event.PutEvents(ev, eventList);
                        }
                        else
                        {
                            var ev = new WaiterDrinksEnd(waiter.Customer, waiter, waiterQueue, clock, Generators.ExponentialDistribution(300));
                            Event.PutEvents(ev, eventList);
                        }
                        Console.WriteLine("Obsługa przez kelnera");
                        Display.ShowEventList();
                        return true;
                    }
                }
            }
        return false;
        }
    }
}
