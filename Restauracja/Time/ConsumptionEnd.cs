using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class ConsumptionEnd:Event
    {
        private readonly List<Customer> CashierQueue;
        private readonly Table Table;
        public ConsumptionEnd(Customer customer, List<Customer> cashierQueue, Table table, int startTime, int executeTime) : base(customer, startTime, executeTime)
        {
            CashierQueue = cashierQueue;
            Table = table;
        }

        public override void Execute()
        {
            CashierQueue.Add(Customer);
            Table.Customer = null;
            Console.WriteLine("Zakonczenie spozywania posiłku");
        }
    }
}
