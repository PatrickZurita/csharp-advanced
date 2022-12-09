
internal class Program
{
    private static void Main(string[] args)
    {
        // Creating the Data Source
        var countries = new List<string> { "Peru", "Argentina", "Colombia", "Mexico", "Iran" };
        
        int[] scores = { 97, 92, 81, 60, 55 };

        int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        var customers = new List<Customer>() { 
           new Customer(1, "London",36),
           new Customer(2, "Lima",15),
           new Customer(3, "Dubai", 27)
        };

        IEnumerable<Customer> ieCustomer = LearningLINQ.objectQuery(customers);

        int index = 1;

        foreach (var cus in ieCustomer) {
            Util<int>.printValue("Customer: ", index++);
            Util<string>.printValue("City: ", cus.city);
            Util<int>.printValue("Id: ", cus.id);
        }
        
        var youngCustomer = LearningLINQ.getYoungCustomer(customers);

        Console.WriteLine(youngCustomer.age);
        Console.WriteLine(youngCustomer.city);           
        Console.WriteLine(youngCustomer.id);           

        //LearningLINQ.TestMethodSintax(countries);
        //LearningLINQ.TestQuerySintax(countries, scores, numbers);

        //int cantAdultCustomers = LearningLINQ.cantAdultCustomersLondon(customers);
        //Util<int>.printValue("Cantidad de adultos que viven en london", cantAdultCustomers);
    }
}