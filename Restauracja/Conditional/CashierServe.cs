using System;
using Restaurant.Time;

namespace Restaurant.Conditional
{
    public class CashierServe : Restaurant
    {
        public static bool Realize()
        {
            if (cashierQueue.Count != 0)
            {
                foreach (var cashier in cashiers)
                {
                    if (cashier.Customer == null)
                    {
                        cashier.Customer = cashierQueue[0];
                        cashierQueue.RemoveAt(0);
                        var ev = new CashierEnd(cashier, clock, Generators.ExponentialDistribution(800));
                        Event.PutEvents(ev, eventList);
                        Console.WriteLine("Obsługa przez kasjera");
                        Display.ShowEventList();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
