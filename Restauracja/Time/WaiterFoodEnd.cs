using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class WaiterFoodEnd : Event
    {
        private readonly List<Customer> CashierQueue;
        private readonly Waiter Waiter;
        private readonly Table Table;
        private readonly List<Event> EventList;
        public WaiterFoodEnd(List<Event> eventList, Customer customer, Waiter waiter, Table table, List<Customer> cashierQueue, int startTime, int executeTime) : base(customer, startTime, executeTime + startTime)
        {
            CashierQueue = cashierQueue;
            EventList = eventList;
            Table = table;
            Waiter = waiter;
            CashierQueue = cashierQueue;
            Table = table;
            EventList = eventList;
        }
        public override void Execute()
        {
            var ev = new ConsumptionEnd(Waiter.Customer, CashierQueue,Table, ExecuteTime, Generators.ExponentialDistribution(1900)+ExecuteTime);
            PutEvents(ev, EventList);
            Waiter.Customer = null;
            Console.WriteLine("Zakończenie podania jedzienia");
            
        }
    }
}
