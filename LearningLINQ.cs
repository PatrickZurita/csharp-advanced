    /* LINQ -> Language Integrated Query */
    class LearningLINQ{
        #region METHOD_SINTAX
        public static IEnumerable<string> methodSintax(List<string> list) {
            return list.Where(l => l.Length <= 6);
        }
        public static string operatorsChaining(List<string> list){
            return list.Where(l => l.Length > 6).OrderByDescending(l => l.Length).First(); // get the largest string
        }
        #endregion
        
        #region QUERY_SINTAX
        public static IEnumerable<string> querySintax(List<string> list) {
            return             
                from l in list            
                where l.Length > 6
                select l;
        }
        public static IEnumerable<int> queryExpression(int []array){
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
        public static void queryOperation(int []array){
            var numQuery = 
                from a in array 
                where (a % 2) == 0
                select a;
             
             foreach (int a in numQuery){
                Console.WriteLine("{0,1} ", a);
             }
        }

        public static int quantityOfEvenNumbers(int []numbers){
            var evenNumQuery =
                from num in numbers  // NUMBERS IS THE DATA SOURCE
                where (num % 2) == 0
                select num;
            return evenNumQuery.Count();
        }
        #endregion
    }