
namespace Restaurant.Objects
{
    public class Table
    {
        public int Seats {get; set; } 
        public Customer Customer {get; set;}
        public Table(int seats)
        {
            Seats = seats;
            Customer = null;
        }
    }
}
