    /* LINQ -> Language Integrated Query */
class LearningLINQ {
    #region METHOD_SINTAX
        public static IEnumerable<string> methodSintax(List<string> list) {
            return list.Where(l => l.Length <= 6);
        }
        public static string operatorsChaining(List<string> list){
            return list.Where(l => l.Length > 6).OrderByDescending(l => l.Length).First(); // get the largest string
        }
        public static int cantAdultCustomersLondon(List<Customer> customers){
            return customers.Where(c => c.age > 18 && c.city.Contains("don"))
                   .OrderBy(c => c.age)
                   .Select(c => new
                   { 
                     id = c.id,
                     age = c.age,
                     city = c.city              
                   }).Count();
        }
    public static Customer getYoungCustomer(List<Customer> customers) => customers.OrderByDescending(c => c.age)
                                                                                  .LastOrDefault();
    public static Customer _getYoungCustomer(List<Customer> customers) {
        Func<Customer, int> keySelector = c => c.age;
        return customers.OrderByDescending(keySelector).LastOrDefault();
    }

    #endregion

    #region QUERY_SINTAX
    public static IEnumerable<string> querySintax(List<string> list) {
            return             
                from l in list            
                where l.Length > 6
                select l;
        }
        public static IEnumerable<int> queryExpression(int []array){
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
        public static void queryOperation(int []array){
            var numQuery = 
                from a in array 
                where (a % 2) == 0
                select a;
             
             foreach (int a in numQuery){
                Console.WriteLine("{0,1} ", a);
             }
        }

        public static int quantityOfEvenNumbers(int []numbers){
            var evenNumQuery =
                from num in numbers  // NUMBERS IS THE DATA SOURCE
                where (num % 2) == 0
                select num;
            return evenNumQuery.Count();
        }

        // Query to list, array..
        public static List<int> queryIntoCollection(int[] numbers){
            return 
                (from num in numbers
                where (num % 2) == 0
                select num).ToList();
        }
        public static int[] _queryIntoCollection(int[] numbers){
            return 
                (from num in numbers
                where (num % 2) == 0
                select num).ToArray();
        }

        public static IEnumerable<Customer> objectQuery(List<Customer> customers) {
            IEnumerable<Customer> customerQuery =
                from cust in customers
                where cust.city == "London"
                select cust;
            return customerQuery;
        } 
    #endregion

    #region TEST_METHOD_SINTAX

            public static void TestMethodSintax(List<string> countries){
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
    public static void TestQuerySintax(List<string> countries, int[] scores, int[] numbers){
        // sintaxis basada en consultas - Query sintax 
        var bigCountries = querySintax(countries);
    
        Util<string>.println("bigCountries: ", bigCountries);
        
        IEnumerable<int> scoresGreater80 = queryExpression(scores);
        
        Util<int>.println("Scores greater than 80: ", scoresGreater80);

        // The following  fuction shows the complete query operation, please look the implemetation.
        queryOperation(numbers); // The query return only pair numbers

        List<int> numQuery2 = queryIntoCollection(numbers);

        Console.WriteLine(numQuery2);

        int [] numQuery3 = _queryIntoCollection(numbers);

        Console.WriteLine(numQuery3);
    }
    #endregion

}