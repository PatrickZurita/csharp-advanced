class Threads{
    public static void ThreadJoin() {
        Thread t = new Thread(PrintNumber);

        t.Name = "Print";
        t.Start();

        var fls = t.Join(1); // false el hilo no podra ejecutar la funcion en 1 ms
        var tru = t.Join(1000); // true el hilo si ejecuta la funcion en los 1000 ms

        Console.WriteLine("Finish thread.");
    }
    public static void PrintNumber() { 
        Console.WriteLine(Thread.CurrentThread.Name);

        // Thread.Sleep(1000);

        for (int i = 100; i >= 0; --i)
            Console.Write(i);
    }
}