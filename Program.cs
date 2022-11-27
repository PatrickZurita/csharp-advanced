
internal class Program
{
    private static void Main(string[] args)
    {
        // Creating the Data Source
        var countries = new List<string> { "Peru", "Argentina", "Colombia", "Mexico", "Iran" };
        
        int[] scores = { 97, 92, 81, 60, 55 };

        int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        LearningLINQ.TestMethodSintax(countries);

        LearningLINQ.TestQuerySintax(countries, scores, numbers);
    }
}