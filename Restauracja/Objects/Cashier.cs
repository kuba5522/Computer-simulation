
namespace Restaurant.Objects
{
    public class Cashier
    {
        public Customer Customer { get; set; }
        public Cashier()
        {
            Customer = null;
        }
    }
}
