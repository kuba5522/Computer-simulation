using System;
using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant.Time
{
    public class AppearanceGroupOfClients : Event
    {
        private readonly List<Customer> TableQueue;
        private readonly List<Customer> BuffetQueue;
        private readonly List<Event> EventList;
        public AppearanceGroupOfClients(List<Customer> tableQueue, List <Customer> buffetQueue,
            List<Event> eventList, int clock, int executeTime) : base(new Customer(), clock, executeTime + clock)
        {
            TableQueue = tableQueue; 
            BuffetQueue = buffetQueue;
            EventList = eventList;
        }
        public override void Execute()
        {
            Console.WriteLine("Pojawienie się grupy klientow");
            if (Customer.Choice2 == Customer.Choice.ToBuffet)
            {
                BuffetQueue.Add(Customer);
            }
            else
                TableQueue.Add(Customer);

            Restaurant.NumberOfPpl++;
            var group = new AppearanceGroupOfClients(TableQueue, BuffetQueue, EventList, Restaurant.clock, Generators.GaussianDistribution(300, 50));
            PutEvents(group, EventList);

        }
        
    }
}
