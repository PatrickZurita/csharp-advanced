
internal class Program
{
    class LearningLINQ{
        public static IEnumerable<string> methodSintax(List<string> list) {
            return list.Where(l => l.Length <= 6);
        }
        public static IEnumerable<string> querySintax(List<string> list) {
            return             
                from l in list            
                where l.Length > 6
                select l;
        }
        public static string operatorsChaining(List<string> list){
            return list.Where(l => l.Length > 6).OrderByDescending(l => l.Length).First(); // get the largest string
        }
    }
        
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

        println("Paisotes: ", paisotes);
        println("Paisitos: ", paisitos);
        println("Paisitos Order By: ", paisitosOrdenados);
        printlnstr("Pais mas largo", paisMasLargo);
    }
    static void println(string tittle, IEnumerable<string> ie){
        Console.WriteLine(tittle);
        ie.ToList().ForEach(p => Console.WriteLine(p));
        Console.WriteLine(" ");
    }
    static void printlnB(string tittle, IEnumerable<string> ie){
        Console.WriteLine(tittle);
        Console.WriteLine(string.Join(",", ie));
        Console.WriteLine(" ");
    }
    static void printlnC(string tittle, IEnumerable<string> ie){
        Console.WriteLine(tittle);
        foreach(var i in ie){
            Console.WriteLine(i);
        }
        Console.WriteLine(" ");
    }
    static void printlnstr(string tittle, string value){
        Console.WriteLine(tittle);
        Console.WriteLine(value);
        Console.WriteLine(" ");
    }
}