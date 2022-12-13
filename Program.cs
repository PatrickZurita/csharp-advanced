
internal class Program
{
    private static void Main(string[] args)
    {
        object myName = "Patrick";

        if (myName is string)
            Console.WriteLine("El nombre {0} tiene {1} caracteres", (string)myName, ((string)myName).Length);

        if (myName is string mn)
            Console.WriteLine("El nombre {0} tiene {1} caracteres", mn, mn.Length);           
    }
}