/* LINQ -> Language Integrated Query */
class LearningLINQ
{
    #region METHOD_SINTAX
    public static IEnumerable<string> methodSintax(List<string> list) => list.Where(l => l.Length <= 6);
    public static string operatorsChaining(List<string> list) => list.Where(l => l.Length > 6).OrderByDescending(l => l.Length).First(); // get the largest string
    public static int cantAdultCustomersLondon(List<Customer> customers)
    {
        return customers.Where(c => c.age > 18 && c.city.Contains("don"))
                       .OrderBy(c => c.age)
                       .Count();
    }
    public static IEnumerable<Customer> AdultCustomersLondon(List<Customer> customers)
    {
        return customers.Where(c => c.age > 18 && c.city.Contains("don"))
                        .OrderBy(c => c.age);
    }

    public static IEnumerable<SomeClass> GetNewListCustomerOnlyIDAndAge(List<Customer> customers) => customers.Where(c => c.age > 18 && c.city.Contains("don"))
                       .OrderBy(c => c.age)
                       .Select(c => new SomeClass(c.city, c.age));

    public static Customer getYoungCustomer(List<Customer> customers) => customers.OrderByDescending(c => c.age).LastOrDefault();
    public static Customer _getYoungCustomer(List<Customer> customers)
    {
        Func<Customer, int> keySelector = c => c.age;
        return customers.OrderByDescending(keySelector).LastOrDefault();
    }
    public static IEnumerable<Customer> getCustomersByFilter(Func<Customer, bool> filter, List<Customer> customers) => customers.Where(filter);
    #endregion

    #region QUERY_SINTAX
    public static IEnumerable<string> querySintax(List<string> list)
    {
        return
            from l in list
            where l.Length > 6
            select l;
    }
    public static IEnumerable<int> queryExpression(int[] array)
    {
        IEnumerable<int> ie =
            from a in array  // Query expression
            where a > 80
            select a;

        return ie;
    }
    /*
            ---DATA SOURCE---
            ITEM 1    ARRAY[0]
            ITEM 2    ARRAY[1]
            ITEM 3    ARRAY[3]
            ---QUERY---
            from ...
            where ...
            select ...
            ---QUERY EXECTUTION---
            foreach(var item in Query) 
    */
    public static void queryOperation(int[] array)
    {
        var numQuery =
            from a in array
            where (a % 2) == 0
            select a;

        foreach (int a in numQuery)
            Console.WriteLine("{0,1} ", a);
    }

    public static int quantityOfEvenNumbers(int[] numbers)
    {
        var evenNumQuery =
            from num in numbers  // NUMBERS IS THE DATA SOURCE
            where (num % 2) == 0
            select num;
        return evenNumQuery.Count();
    }

    // Query to list, array..
    public static List<int> queryIntoCollection(int[] numbers)
    {
        return
            (from num in numbers
             where (num % 2) == 0
             select num).ToList();
    }
    public static int[] _queryIntoCollection(int[] numbers)
    {
        return
            (from num in numbers
             where (num % 2) == 0
             select num).ToArray();
    }

    public static IEnumerable<Customer> objectQuery(List<Customer> customers)
    {
        IEnumerable<Customer> customerQuery =
            from cust in customers
            where cust.city == "London"
            select cust;
        return customerQuery;
    }
    #endregion
    #region TEST_NICE_FUNCTIONS
    public void TestNiceFunctions()
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

        IEnumerable<SomeClass> iec = LearningLINQ.GetNewListCustomerOnlyIDAndAge(customers);
        foreach (var c in iec)
        {
            Util<string>.printValue("City: ", c.city);
            Util<int>.printValue("Age: ", c.age);
        }

        Util<int>.printValue("-> ", iec.Count());
    }
    #endregion

    #region TEST_METHOD_SINTAX
    public static void TestMethodSintax(List<string> countries)
    {
        // sintaxis basada en metodos - Method sintax
        var littleCountries = methodSintax(countries);

        // encadenamiento de operadores - operators chaining
        var littleCountriesOrdenados = countries.Where(p => p.Length <= 6).OrderBy(p => p);

        var largestCountry = operatorsChaining(countries);

        Util<string>.println("littleCountries: ", littleCountries);
        Util<string>.println("littleCountries Order By: ", littleCountriesOrdenados);
        Util<string>.printValue("Pais mas largo", largestCountry);
    }
    #endregion

    #region TEST_QUERY_SINTAX
    public static void TestQuerySintax(List<string> countries, int[] scores, int[] numbers)
    {
        // sintaxis basada en consultas - Query sintax 
        var bigCountries = querySintax(countries);

        Util<string>.println("bigCountries: ", bigCountries);

        IEnumerable<int> scoresGreater80 = queryExpression(scores);

        Util<int>.println("Scores greater than 80: ", scoresGreater80);

        // The following  fuction shows the complete query operation, please look the implemetation.
        queryOperation(numbers); // The query return only pair numbers

        List<int> numQuery2 = queryIntoCollection(numbers);

        Console.WriteLine(numQuery2);

        int[] numQuery3 = _queryIntoCollection(numbers);

        Console.WriteLine(numQuery3);
    }
    #endregion
    public static void TestSomething()
    {
        // Creating the Data Source
        //var countries = new List<string> { "Peru", "Argentina", "Colombia", "Mexico", "Iran" };

        //int[] scores = { 97, 92, 81, 60, 55 };

        //int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
        //LearningLINQ.TestMethodSintax(countries);
        //LearningLINQ.TestQuerySintax(countries, scores, numbers);

        //int cantAdultCustomers = LearningLINQ.cantAdultCustomersLondon(customers);
        //Util<int>.printValue("Cantidad de adultos que viven en london", cantAdultCustomers);



        /*IEnumerable<Customer> ieCustomer = LearningLINQ.objectQuery(customers);

        foreach (var cus in ieCustomer) {
            Util<int>.printValue("Customer: ", cus.id);
            Util<string>.printValue("City: ", cus.city);
            Util<int>.printValue("Id: ", cus.id);
        }
        
        var youngCustomer = LearningLINQ.getYoungCustomer(customers);

        Console.WriteLine(youngCustomer.age);
        Console.WriteLine(youngCustomer.city);           
        Console.WriteLine(youngCustomer.id);*/
    }
}