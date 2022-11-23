    /* LINQ -> Language Integrated Query */
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