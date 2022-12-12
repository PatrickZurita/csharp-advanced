
internal class Program
{
    private static void Main(string[] args)
    {
        List<Curso> cursos = new List<Curso>()
        {
            new Curso
            {
                Id = "ES-prog-001",
                Tittle = "R for Data Science",
                Description = "R basic to advanced",
                Duration = 9000,
                Nivel = 1,
                Area = Area.DataScience
            },
            new Curso
            {
                Id = "ES-prog-002",
                Tittle = "React for dummies",
                Description = "Learn React basic to advanced",
                Duration = 14000,
                Nivel = 2,
                Area = Area.Developer
            },
            new Curso
            {
                Id = "ES-prog-003",
                Tittle = "LINQ",
                Description = "Linq basic to advanced",
                Duration = 18000,
                Nivel = 2,
                Area = Area.CSharp
            }
        };

        var instructores = new List<Instructor>()
        {
            new Instructor()
            {
                Name = "Patrick Zurita",
                Bio = "Software engineer",
                Area = Area.Developer
            },
            new Instructor()
            {
                Name = "Vieri Tenorio",
                Bio = "Master Bussisnes Administration",
                Area = Area.BussisnesInteligence
            },
            new Instructor()
            {
                Name = "Ivar the Boneless",
                Bio = "The best data scientist in the world",
                Area = Area.DataScience
            }
        };
    }
}