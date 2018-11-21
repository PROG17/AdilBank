namespace AdilBank.Models
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Customer Customer { get; set; }
    }
}