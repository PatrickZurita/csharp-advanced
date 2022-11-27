
internal class Program
{
    private static void Main(string[] args)
    {

        #region TEST_QUERY_METHOD_OPERATORS_CHAINING

        var paises = new List<string> { "Peru", "Argentina", "Colombia", "Mexico", "Iran" };

        // sintaxis basada en metodos - Method sintax
        var paisitos = LearningLINQ.methodSintax(paises);

        // sintaxis basada en consultas - Query sintax 
        var paisotes = LearningLINQ.querySintax(paises);
    
        // encadenamiento de operadores - operators chaining
        var paisitosOrdenados = paises.Where(p => p.Length <= 6).OrderBy(p => p);

        var paisMasLargo = LearningLINQ.operatorsChaining(paises);
        
        /* Util.println("Paisotes: ", paisotes);
        Util.println("Paisitos: ", paisitos);
        Util.println("Paisitos Order By: ", paisitosOrdenados);
        Util.printlnstr("Pais mas largo", paisMasLargo); */
        #endregion

        #region QUERY_EXPRESSION
        
        int[] scores = { 97, 92, 81, 60, 55 };
        
        IEnumerable<int> scoresGreater80 = LearningLINQ.queryExpression(scores);

        //Util<int>.println("Scores greater than 80: ", scoresGreater80);
        
        #endregion

        #region QUERY_OPERATION
        
        // Creating the Data Source
        int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        LearningLINQ.queryOperation(numbers); // The query return only pair numbers

        #endregion
    }
}