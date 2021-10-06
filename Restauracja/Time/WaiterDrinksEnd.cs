using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class WaiterDrinksEnd : Event
    {
        readonly List<Customer> WaiterQueue;
        private readonly Waiter Waiter;
        public WaiterDrinksEnd(Customer customer, Waiter waiter, List<Customer> waiterQueue, int startTime, int executeTime) : base(customer, startTime, executeTime + startTime)
        {
            WaiterQueue = waiterQueue;
            Waiter = waiter;
        }
        public override void Execute()
        {
            Customer.FoodServe = true;
            WaiterQueue.Add(Customer);
            Waiter.Customer = null;
            Console.WriteLine("Zakończenie podania napojów");
        }
    }
}
