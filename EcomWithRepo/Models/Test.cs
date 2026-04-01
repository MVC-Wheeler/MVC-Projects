namespace Ecom.Models
{
    public class Test: Itest
    {
        public int Counter { get; set; } = 0;

        public int add()
        {
            Counter++;
            return Counter;
        }
    }
}
