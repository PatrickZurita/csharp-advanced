class PatternAttributeMatching
{
    public static void PatternMatching()
    {
        object myName = "Patrick";

        if (myName is string mn) 
            Console.WriteLine("El nombre {0} tiene {1} caracteres", mn, mn.Length);
    }

    public static void PropertyPatterns() 
    {
        Peticion pet = new Peticion
        {
            Puerto = 8081,
            Metodo = "GET",
            TipoDeContenido = "child"
        };

        bool verifyAdultContent(Peticion p) => p switch
        {
            { TipoDeContenido: "adult" } => true, _ => false
        };

        bool verifyPortHas4DigitsAndMethodIsPut(Peticion p) => p switch
        {
            { Metodo: "PUT" } when p.Puerto.ToString().Length == 4 => true, _ => false
        };

        bool verifyIfPortIsAEvenNumber(Peticion p) => p switch
        {
            { Puerto: int port } => port % 2 == 0, _ => false
        }; 

        bool easyVerify(Peticion p) => p.Puerto % 2 == 0;
        
        bool verifyMethodIsGetAndTheContentIsChildAndPortIsOdd(Peticion p) => p switch
        {
            { Metodo: "GET", TipoDeContenido: "child" } when p.Puerto % 2 != 0 => true, _ => false
        };

        Console.WriteLine(verifyMethodIsGetAndTheContentIsChildAndPortIsOdd(pet));
    }
        internal enum Moneda
        {
            PEN,
            EUR,
            USD
        }
        public static decimal ConvertCurrency(decimal amount, Moneda inicial, Moneda final) => 
        (inicial, final) switch
        {
            (Moneda.PEN, Moneda.USD) => (amount * 3.5m),// obtener dinamicamente el valor del dolar 
            (Moneda.USD, Moneda.PEN) => (amount * 0.035m),
            _ => throw new Exception("F") 
        };

        public static void TuplePatterns()
        {
            Console.WriteLine(ConvertCurrency(1000, Moneda.USD, Moneda.PEN));
        }
}