
internal class Program
{
    private static void Main(string[] args)
    {
        var customers = new List<Customer>() {
           new Customer(1, "London",36),
           new Customer(2, "Lima",15),
           new Customer(3, "Dubai", 27),
           new Customer(4, "London",24),
        };

        Func<Customer, bool> filter = c => c.city == "London" && c.age > 18;

        IEnumerable<Customer> customersByFilter = LearningLINQ.getCustomersByFilter(filter, customers);

        foreach (var c in customersByFilter)
        {
            Util<string>.printValue("City: ", c.city);
            Util<int>.printValue("Age: ", c.age);
        }
    }
}