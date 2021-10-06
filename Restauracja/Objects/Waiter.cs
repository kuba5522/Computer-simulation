

namespace Restaurant.Objects
{
    public class Waiter
    {
        public Customer Customer { get; set; }
        public Waiter()
        {
            Customer = null;
        }
    }
}
