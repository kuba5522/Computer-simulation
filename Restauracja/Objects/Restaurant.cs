using System.Collections.Generic;
using Restaurant.Objects;

namespace Restaurant
{
    public class Restaurant
    {
        
        protected const int K = 3; //liczba kelnerów
        protected const int N2 = 4; //stolik 2 osobowy
        protected const int N3 = 10; //stoliki 3 osobowe
        protected const int N4 = 4; //stoliki 4 osobowe
        protected const int AllTables = N2 + N3 + N4;
        protected const int S = 30; //prowadzenie przez kierownika
        protected const int B = 14; //osoby 
        protected const int C = 4; //kasjerzy
        public static int clock = 0;
        public static int NumberOfPpl { get; set; } = 0;
        protected static List<Waiter> waiters { get; set; } = new List<Waiter>();
        protected static List<Table> tables { get; set; } = new List<Table>();
        protected static List<Cashier> cashiers { get; set; } = new List<Cashier>();
        protected static Manager manager { get; set; } = new Manager();
        protected static Buffet buffets { get; set; } = new Buffet(B);
        protected static List<Customer> tableQueue { get; set; } = new List<Customer>();
        protected static List<Customer> buffetQueue { get; set; } = new List<Customer>();
        protected static List<Customer> cashierQueue { get; set; } = new List<Customer>();
        protected static List<Customer> waiterQueue { get; set; } = new List<Customer>();
        protected static List<Event> eventList { get; set; } = new List<Event>();
        public static List<Event> pastEventList { get; set; } = new List<Event>();

    }
}
