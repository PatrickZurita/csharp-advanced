
internal class Program
{
    private static void Main(string[] args)
    {
        
        var countries = new List<string> { "Peru", "Argentina", "Colombia", "Mexico", "Iran" };
        
        int[] scores = { 97, 92, 81, 60, 55 };

        // Creating the Data Source
        int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        #region TEST_METHOD_SINTAX

        // sintaxis basada en metodos - Method sintax
        var littleCountries = LearningLINQ.methodSintax(countries);

        // encadenamiento de operadores - operators chaining
        var littleCountriesOrdenados = countries.Where(p => p.Length <= 6).OrderBy(p => p);
        
        var largestCountry = LearningLINQ.operatorsChaining(countries);

        /*Util<string>.println("littleCountries: ", littleCountries);
        Util<string>.println("littleCountries Order By: ", littleCountriesOrdenados);
        Util<string>.printlnstr("Pais mas largo", largestCountry);*/

        #endregion

        #region TEST_QUERY_SINTAX

        // sintaxis basada en consultas - Query sintax 
        var bigCountries = LearningLINQ.querySintax(countries);
    
        //Util<string>.println("bigCountries: ", bigCountries);
        
        IEnumerable<int> scoresGreater80 = LearningLINQ.queryExpression(scores);
        
        //Util<int>.println("Scores greater than 80: ", scoresGreater80);

        // The following  fuction shows the complete query operation, please look the implemetation.
        LearningLINQ.queryOperation(numbers); // The query return only pair numbers

        #endregion
    }
}