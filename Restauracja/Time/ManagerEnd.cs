using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class ManagerEnd : Event
    {
        private readonly Manager Manager;
        private readonly List<Customer> WaiterQueue;
        public ManagerEnd(List<Customer> waiterQueue, Manager manager, int startTime, int executeTime) : base(manager.Customer, startTime,
            executeTime + startTime)
        {
            Manager = manager;
            WaiterQueue = waiterQueue;
        }
        public override void Execute()
        {
            WaiterQueue.Add(Manager.Customer);
            Manager.Customer = null;
            Console.WriteLine("Zakończenie obsługi przez menagera");
        }
    }
}
