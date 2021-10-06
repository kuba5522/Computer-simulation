using System;
using System.Collections.Generic;
using Restaurant.Objects;
using Restaurant.Time;

namespace Restaurant
{
    public abstract class Event
    {
        public int ExecuteTime { get; set; }

        public Customer Customer { get; set; }

        
        protected Event(Customer customer, int startTime, int executeTime)
        {
            int StartTime = startTime;
            ExecuteTime = executeTime;
            Customer = customer;
            Restaurant.pastEventList.Add(this);
            Calculations(typeof(ManagerEnd), typeof(AppearanceGroupOfClients), StartTime, 7);
            Calculations(typeof(WaiterDrinksEnd), typeof(ManagerEnd), ExecuteTime, 8);
            Calculations(typeof(WaiterFoodEnd), typeof(WaiterDrinksEnd), StartTime, 9);

        }

        private void Calculations(Type type, Type type1, int minuend, int j)
        {
            if (GetType() == type)
                for (int i = Restaurant.pastEventList.Count - 1; i >= 0; i--)
                {
                    if (Restaurant.pastEventList[i].GetType() == type1 &&
                        Restaurant.pastEventList[i].Customer.Id == Customer.Id)
                    {
                        CreateExcelFile.SaveToExcel(minuend - Restaurant.pastEventList[i].ExecuteTime, j);
                        break;
                    }
                }
        }

        public abstract void Execute();
        

        public static void PutEvents(Event ev, List<Event> events)
        {
            if (events.Count >= 1)
            {
                events.Add(null);
                for (int i = events.Count - 1; i >= 0; i--)
                {
                    if (i == 0 || events[i - 1].ExecuteTime < ev.ExecuteTime)
                    {
                        events[i] = ev;
                        break;
                    }

                    events[i] = events[i-1];
                }
            }
            else
            {
                events.Add(ev);
            }

        }
    }
}
