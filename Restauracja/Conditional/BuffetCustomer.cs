using System;
using Restaurant.Time;

namespace Restaurant.Conditional
{
    public class BuffetCustomer : Restaurant
    {
        public static bool Realize()
        {
            if (buffetQueue.Count != 0 && buffetQueue[0].NumberOfPeople <= buffets.CheckFreeSeats())
            {
                buffets.ListOfCustomers.Add(buffetQueue[0]);
                var ev = new BuffetEnd(buffetQueue[0], buffets, cashierQueue, clock, Generators.GaussianDistribution(3200, 100));
                buffetQueue.RemoveAt(0);
                Event.PutEvents(ev, eventList);
                Console.WriteLine("Przydzielenie klienta do bufetu");
                Display.ShowEventList();
                return true;
            }
            return false;
        }
    }
}
