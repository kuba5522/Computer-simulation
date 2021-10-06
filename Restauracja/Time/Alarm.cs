using System;
using System.Collections.Generic;

namespace Restaurant.Time
{
    public class Alarm : Event
    {
        private readonly List<Event> EventList;
        public Alarm(List<Event> eventList, int executeTime, int startTime) : base(null, startTime, executeTime + startTime)
        {
            EventList = eventList;
        }
        public override void Execute()
        {
            AlarmDelete.DeleteFromQueue();
            var alarm = new Alarm(EventList, Generators.GaussianDistribution(4200, 50), Restaurant.clock);
            PutEvents(alarm, EventList);
            Console.WriteLine("ALARM");
        }
    }
}
