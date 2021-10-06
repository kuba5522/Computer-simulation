using System;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class CashierEnd : Event
    {
        private readonly Cashier Cashier;
        public CashierEnd(Cashier cashier, int startTime, int executeTime) : base(cashier.Customer, startTime, executeTime + startTime)
        {
            Cashier = cashier;
        }
        public override void Execute()
        {
            Cashier.Customer = null;
            Console.WriteLine("Zakończenie obsługi przez kasjera");
            
        }
    }
}
