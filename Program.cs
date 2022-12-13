
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
                Nivel = 2,
                Area = Area.DataScience
            },
            new Curso
            {
                Id = "ES-busi-002",
                Tittle = "Business like goodfellas",
                Description = "Learn Busisness",
                Duration = 36000,
                Nivel = 3,
                Area = Area.BussisnesInteligence
            },
            new Curso
            {
                Id = "ES-prog-003",
                Tittle = "React for dummies",
                Description = "Learn React basic to advanced",
                Duration = 14000,
                Nivel = 2,
                Area = Area.Developer
            },
            new Curso
            {
                Id = "ES-prog-004",
                Tittle = "LINQ",
                Description = "Linq basic to advanced",
                Duration = 18000,
                Nivel = 1,
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

        var cursosPorInstructor = cursos.Where(c => c.Id.Contains("prog"))
            .Join(instructores,
                c => c.Area,
                i => i.Area,
                (c, i) => new
                {
                    c.Id,
                    c.Tittle,
                    c.Nivel,
                    instructor = i.Name
                }
            ).GroupBy(ci => ci.instructor);

        var cursosDuracionMayores15000 = cursos.Where(c=> c.Duration > 15000)
            .Select(c => new 
            {
                c.Tittle,
                c.Description,
                c.Duration
            });

        Console.WriteLine(cursosDuracionMayores15000);
        Console.WriteLine(cursosPorInstructor);
    }
}