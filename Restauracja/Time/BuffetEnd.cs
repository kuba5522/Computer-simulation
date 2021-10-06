using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class BuffetEnd : Event
    {
        private readonly List<Customer> CashierQueue;
        private readonly Buffet Buffet;
        public BuffetEnd(Customer customer, Buffet buffet, List<Customer> cashierQueue, int startTime, int executeTime) : base(customer, startTime, executeTime + Restaurant.clock)
        {
            Buffet = buffet;
            CashierQueue = cashierQueue;
        }

        public override void Execute()
        {
            CashierQueue.Add(Customer);
            Buffet.DeleteFromList(Customer);
            Console.WriteLine("Zakonczenie wizyty w bufecie");
        }
    }
}
