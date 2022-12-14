/* LINQ -> Language Integrated Query */
class LearningLINQ
{
    #region METHOD_SINTAX
    public static IEnumerable<string> MethodSintax(List<string> list) => list.Where(l => l.Length <= 6);
    public static string OperatorsChaining(List<string> list) => list.Where(l => l.Length > 6).OrderByDescending(l => l.Length).First(); // get the largest string
    public static int CantAdultCustomersLondon(List<Customer> customers)
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

    public static Customer GetYoungCustomer(List<Customer> customers) => customers.OrderByDescending(c => c.age).LastOrDefault();
    public static Customer _GetYoungCustomer(List<Customer> customers)
    {
        Func<Customer, int> keySelector = c => c.age;
        return customers.OrderByDescending(keySelector).LastOrDefault();
    }
    public static IEnumerable<Customer> GetCustomersByFilter(Func<Customer, bool> filter, List<Customer> customers) => customers.Where(filter);
    #endregion

    #region QUERY_SINTAX
    public static IEnumerable<string> QuerySintax(List<string> list)
    {
        return
            from l in list
            where l.Length > 6
            select l;
    }
    public static IEnumerable<int> QueryExpression(int[] array)
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
    public static void QueryOperation(int[] array)
    {
        var numQuery =
            from a in array
            where (a % 2) == 0
            select a;

        foreach (int a in numQuery)
            Console.WriteLine("{0,1} ", a);
    }

    public static int QuantityOfEvenNumbers(int[] numbers)
    {
        var evenNumQuery =
            from num in numbers  // NUMBERS IS THE DATA SOURCE
            where (num % 2) == 0
            select num;
        return evenNumQuery.Count();
    }

    // Query to list, array..
    public static List<int> QueryIntoCollection(int[] numbers)
    {
        return
            (from num in numbers
             where (num % 2) == 0
             select num).ToList();
    }
    public static int[] _QueryIntoCollection(int[] numbers)
    {
        return
            (from num in numbers
             where (num % 2) == 0
             select num).ToArray();
    }

    public static IEnumerable<Customer> ObjectQuery(List<Customer> customers)
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

        IEnumerable<Customer> customersByFilter = LearningLINQ.GetCustomersByFilter(filter, customers);

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
        var littleCountries = MethodSintax(countries);

        // encadenamiento de operadores - operators chaining
        var littleCountriesOrdenados = countries.Where(p => p.Length <= 6).OrderBy(p => p);

        var largestCountry = OperatorsChaining(countries);

        Util<string>.println("littleCountries: ", littleCountries);
        Util<string>.println("littleCountries Order By: ", littleCountriesOrdenados);
        Util<string>.printValue("Pais mas largo", largestCountry);
    }
    #endregion

    #region TEST_QUERY_SINTAX
    public static void TestQuerySintax(List<string> countries, int[] scores, int[] numbers)
    {
        // sintaxis basada en consultas - Query sintax 
        var bigCountries = QuerySintax(countries);

        Util<string>.println("bigCountries: ", bigCountries);

        IEnumerable<int> scoresGreater80 = QueryExpression(scores);

        Util<int>.println("Scores greater than 80: ", scoresGreater80);

        // The following  fuction shows the complete query operation, please look the implemetation.
        QueryOperation(numbers); // The query return only pair numbers

        List<int> numQuery2 = QueryIntoCollection(numbers);

        Console.WriteLine(numQuery2);

        int[] numQuery3 = _QueryIntoCollection(numbers);

        Console.WriteLine(numQuery3);
    }

    public static void TestJoinLINQ()
    {
        List<Curso> cursos = new List<Curso>()
        {
            new Curso
            {
                Id = "ES-prog-001",
                Tittle = "R for Data Science",
                Description = "R basic to advanced",
                Duration = 9000,
                Nivel = 2,
                Area = Area.DataScience
            },
            new Curso
            {
                Id = "ES-busi-002",
                Tittle = "Business like goodfellas",
                Description = "Learn Busisness",
                Duration = 36000,
                Nivel = 3,
                Area = Area.BussisnesInteligence
            },
            new Curso
            {
                Id = "ES-prog-003",
                Tittle = "React for dummies",
                Description = "Learn React basic to advanced",
                Duration = 14000,
                Nivel = 2,
                Area = Area.Developer
            },
            new Curso
            {
                Id = "ES-prog-004",
                Tittle = "LINQ",
                Description = "Linq basic to advanced",
                Duration = 18000,
                Nivel = 1,
                Area = Area.CSharp
            }
        };

        var instructores = new List<Instructor>()
        {
            new Instructor()
            {
                Name = "Patrick Zurita",
                Bio = "Software engineer",
                Area = Area.Developer
            },
            new Instructor()
            {
                Name = "Vieri Tenorio",
                Bio = "Master Bussisnes Administration",
                Area = Area.BussisnesInteligence
            },
            new Instructor()
            {
                Name = "Ivar the Boneless",
                Bio = "The best data scientist in the world",
                Area = Area.DataScience
            }
        };

        var cursosPorInstructor = cursos.Where(c => c.Id.Contains("prog"))
            .Join(instructores,
                c => c.Area,
                i => i.Area,
                (c, i) => new
                {
                    c.Id,
                    c.Tittle,
                    c.Nivel,
                    instructor = i.Name
                }
            ).GroupBy(ci => ci.instructor);

        var cursosDuracionMayores15000 = cursos.Where(c => c.Duration > 15000)
            .Select(c => new
            {
                c.Tittle,
                c.Description,
                c.Duration
            });

        Console.WriteLine(cursosDuracionMayores15000);
        Console.WriteLine(cursosPorInstructor);
    }
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
    #endregion
}