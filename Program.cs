
internal class Program
{
    private static void Main(string[] args)
    {
        var paises = new List<string> { "Peru", "Argentina", "Colombia", "Mexico", "Iran" };

        // sintaxis basada en metodos - Method sintax
        var paisitos = LearningLINQ.methodSintax(paises);

        // sintaxis basada en consultas - Query sintax 
        var paisotes = LearningLINQ.querySintax(paises);
    
        // encadenamiento de operadores - operators chaining
        var paisitosOrdenados = paises.Where(p => p.Length <= 6).OrderBy(p => p);

        var paisMasLargo = LearningLINQ.operatorsChaining(paises);

        Util.println("Paisotes: ", paisotes);
        Util.println("Paisitos: ", paisitos);
        Util.println("Paisitos Order By: ", paisitosOrdenados);
        Util.printlnstr("Pais mas largo", paisMasLargo);
    }
}