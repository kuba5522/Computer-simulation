using System.Collections.Generic;

namespace Restaurant.Objects
{
    public class Buffet
    {
        public List<Customer> ListOfCustomers { get; set; } = new List<Customer>();
        private int NumberOfFreeSeats;
        public int MaxPeople { get; }
        public Buffet(int maxPeople)
        {
            MaxPeople = maxPeople;
        }
        public int CheckFreeSeats() //sprawdzanie wolnych miejsc w bufecie
        {
        NumberOfFreeSeats = MaxPeople;
            foreach (var customer2 in ListOfCustomers)
            {
                NumberOfFreeSeats -= customer2.NumberOfPeople;
            }
            return NumberOfFreeSeats;
        }
        public void DeleteFromList(Customer customer)
        {
            foreach (var customer2 in ListOfCustomers)
            {
                if (customer2.Id == customer.Id)
                {
                    ListOfCustomers.Remove(customer);
                    break;
                }
            }
        }
    }
}
