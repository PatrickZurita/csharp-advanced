    class Util { //TODO add generic attribute public class GenericAttribute<T> : Attribute { }
        public static void println(string tittle, IEnumerable<string> ie){
            Console.WriteLine(tittle);
            ie.ToList().ForEach(p => Console.WriteLine(p));
            Console.WriteLine(" ");
        }
        public static void printlnB(string tittle, IEnumerable<string> ie){
            Console.WriteLine(tittle);
            Console.WriteLine(string.Join(",", ie));
            Console.WriteLine(" ");
        }
        public static void printlnC(string tittle, IEnumerable<string> ie){
            Console.WriteLine(tittle);
            foreach(var i in ie){
                Console.WriteLine(i);
            }
            Console.WriteLine(" ");
        }
        public static void printlnstr(string tittle, string value){
            Console.WriteLine(tittle);
            Console.WriteLine(value);
            Console.WriteLine(" ");
        }
    }