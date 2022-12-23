class Threads
{
    public static void SignalingThreads(){
        var e = new ManualResetEvent(false);

        new Thread( () => {
            Console.WriteLine("Waiting..");
            e.WaitOne(); // esperando senial
            e.Dispose();
            Console.WriteLine("Received signal"); // solo si se recibe la senial
        }).Start();

        Thread.Sleep(2000);
        e.Set(); // enviamos la senial
        e.Reset(); // reiniciamos la senial 
    }
    public static void PriorityThreads(){ 
        Thread tx = new Thread(PrintLetterX);
        tx.Priority = ThreadPriority.Highest;
        Thread tz = new Thread(PrintLetterZ);
        tz.Priority = ThreadPriority.Lowest;

        tx.Start();
        tz.Start();
    }
    public static void ExceptionHandlingInThreads()
    {
        try
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            PrintNumbers(100);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public static void LambdaFunctionsWithThreads()
    {
        new Thread(() =>
        {
            PrintNumbers();
            Console.WriteLine("Lambda Thread");
        }).Start();

        for (int i = 100; i >= 0; --i)
        {
            int temp = i;
            new Thread(() => Console.WriteLine(temp)).Start();
        }
    }
    public static void ThreadJoin()
    {
        Thread t = new Thread(PrintNumbers);

        t.Name = "Print";
        t.Start();

        var fls = t.Join(1); // false el hilo no podra ejecutar la funcion en 1 ms
        var tru = t.Join(1000); // true el hilo si ejecuta la funcion en los 1000 ms

        Console.WriteLine("Finish thread.");
    }
    public static void PrintNumbers()
    {
        Console.WriteLine(Thread.CurrentThread.Name);

        // Thread.Sleep(1000);

        for (int i = 100; i >= 0; --i)
            Console.Write(i);
    }
    public static void PrintNumbers(int begin)
    {
        for (int i = begin; i >= 0; --i)
            Console.Write(i);
    }
    public static void PrintLetterX()
    {
        for (int i = 15; i >= 0; --i)
            Console.Write("X");

        Console.WriteLine("Finish Thread X");
    }
    public static void PrintLetterZ()
    {
        for (int i = 15; i >= 0; --i)
            Console.Write("Z");

        Console.WriteLine("Finish Thread Z");
    }
}