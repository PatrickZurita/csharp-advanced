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
        public static IEnumerable<int> queryExpression(int []array){
            IEnumerable<int> ie =                 
                from a in array  // Query expression
                where a > 80
                select a;
            
            return ie;
        }
        public static void queryOperation(int []array){
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
            var numQuery = 
                from a in array 
                where (a % 2) == 0
                select a;
             
             foreach (int a in numQuery){
                Console.WriteLine("{0,1} ", a);
             }
        }
    }