    class Util<T> { //TODO add generic attribute public class GenericAttribute<T> : Attribute { }
        public static void println(string tittle, IEnumerable<T> ie){
            Console.WriteLine(tittle);
            ie.ToList().ForEach(p => Console.WriteLine(p));
            Console.WriteLine(" ");
        }
        public static void printlnB(string tittle, IEnumerable<T> ie){
            Console.WriteLine(tittle);
            Console.WriteLine(string.Join(",", ie));
            Console.WriteLine(" ");
        }
        public static void printlnC(string tittle, IEnumerable<T> ie){
            Console.WriteLine(tittle);
            foreach(var i in ie){
                Console.WriteLine(i);
            }
            Console.WriteLine(" ");
        }
        public static void printValue(string tittle, T value){
            Console.WriteLine(tittle + " " + value);
        }
    }