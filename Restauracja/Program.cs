using System;
using Restaurant.Conditional;
using Restaurant.Objects;
using Restaurant.Time;

namespace Restaurant
{
    internal class Program : Restaurant
    {

        private static void Main()
        {
            Initialization(); //inicjalizacja
            Console.WriteLine("Tryb krokowy : t/n");
            string key = Console.ReadLine();
            Console.WriteLine();
            CreateExcelFile.SaveToExcel("Liczba osob w restauracji",1);
            CreateExcelFile.SaveToExcel("Zegar", 2);
            CreateExcelFile.SaveToExcel("Długosc kolejki oczekujących na stolik", 5);
            CreateExcelFile.SaveToExcel("Długosc kolejki przy kasach", 6);
            CreateExcelFile.SaveToExcel("Czas oczekiwania na stolik", 7);
            CreateExcelFile.SaveToExcel("Czas oczekiwania na napój", 8);
            CreateExcelFile.SaveToExcel("Czas oczekiwania na danie główne", 9);

            var groupOfClients = new AppearanceGroupOfClients(tableQueue, buffetQueue, eventList, clock, 0); //A, tworzenie nowej grupy
            Event.PutEvents(groupOfClients, eventList);
            var alarm = new Alarm(eventList, Generators.GaussianDistribution(4200, 50), clock );
            Event.PutEvents(alarm, eventList);
            while (NumberOfPpl < 5000)
            {
                if (NumberOfPpl > 300)                  //początek zbnierania statystk po fazie początkowej
                {
                    CreateExcelFile.i++;
                    CreateExcelFile.SaveToExcel(GroupsInRestaurant(), 1);
                    CreateExcelFile.SaveToExcel(clock, 2);
                    CreateExcelFile.SaveToExcel(tableQueue.Count, 5);
                    CreateExcelFile.SaveToExcel(cashierQueue.Count, 6);
                }
                clock = eventList[0].ExecuteTime;
                Console.WriteLine("Clock: " + clock + "\n");
                for (int i = 0; i < eventList.Count; i++) //B, znalezienie pierwszego eventu w kalendarzu zdarzeń
                {
                    if (clock == eventList[i].ExecuteTime)
                    {
                        eventList[i].Execute();
                        eventList.RemoveAt(i);
                        Display.ShowEventList();
                    }
                    else
                        break;
                }
                bool x = true;
                while (x)
                {
                    if (!(BuffetCustomer.Realize() || ManagerServe.Realize() || CashierServe.Realize() ||                   //C
                          WaiterOrder.Realize()))
                        x = false;
                }
                Console.WriteLine();
                Console.WriteLine("Liczba osób przy bufecie:" + Display.ShowPplInBuffet(buffets) + "/" + buffets.MaxPeople+"\n"+
                                  "Liczba grup przy stolikach:" + Display.ShowPplInTables()+"/"+AllTables+
                                  " przy kasach:"+ Display.ShowPplInCashiers()+"/"+C +
                                  " u kierownika: "+ manager.Customer);
                Console.WriteLine("Kolejka do stolikow:"+Display.ShowPplInQueue(tableQueue) + " do bufetu:" + Display.ShowPplInQueue(buffetQueue) + 
                                  " do kelnerow:" + Display.ShowPplInQueue(waiterQueue) + " do kas:" + Display.ShowPplInQueue(cashierQueue));
                Console.WriteLine("_______________________________________________");
                if (key == "t")
                    Console.ReadKey();
            }
            Console.WriteLine(pastEventList.Count+"XD");
            CreateExcelFile.SaveFile();
            Console.ReadKey();
        }
        private static void Initialization() //tworzenie
        {
          for (int i=0; i<K; i++) //kelnerzy
            waiters.Add(new Waiter());

          for (int i=0; i<N2; i++) //stoliki 2 osobowe
              tables.Add(new Table(2));

          for (int i = 0; i < N3; i++) //stoliki 3 osobowe
              tables.Add(new Table(3));

          for (int i = 0; i < N4; i++) //stoliki 4 osobowe
              tables.Add(new Table(4));

          for (int i = 0; i < C; i++) //kasjerzy
              cashiers.Add(new Cashier());
        }

        private static int GroupsInRestaurant()
        {
            var groups = tableQueue.Count + buffetQueue.Count + cashierQueue.Count;
            foreach (Table Table in tables)
            {
                if (Table.Customer != null)
                    groups++;
            }

            foreach (var Cashier in cashiers)
            {
                if (Cashier.Customer != null)
                    groups++;
            }

            foreach (var unused in buffets.ListOfCustomers)
                groups++;
            return groups;
        }
    }
}
