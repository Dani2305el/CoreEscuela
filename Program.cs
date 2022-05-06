using CoreEscuela.Entidades;
using static System.Console;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {

            Escuela MiEscuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                pais: "Colombia", ciudad: "Bogota");

            MiEscuela.Cursos = new Curso[] {
                        new Curso(){Nombre = "102"},
                        new Curso(){Nombre = "201"},
                        new Curso{Nombre = "302"}
            };

            ImprimirCursosEscuela(MiEscuela);

            bool rta = 20 == 20;
            int cantidad = 20;
            if (rta==false)
            {
                WriteLine("Se cumpló la condición #1");
            }
            else if (cantidad>50)
            {
                WriteLine("Se cumpló la condición #2");
            }
            else{
                WriteLine("Ninguna se cumplió");
            }

            if(cantidad>5 && rta == false)
            {
                WriteLine("Se cumpló la condición #3");
            }
            if(cantidad>5 && rta)
            {
                WriteLine("Se cumpló la condición #4");
            }
            if(cantidad>50 || rta)
            {
                WriteLine("Se cumpló la condición #5");
            }
            if( (cantidad>50 || rta) && (cantidad%2==0))
            {
                WriteLine("Se cumpló la condición #6");
            }
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la escuela");
            WriteLine("====================");

            if (escuela?.Cursos != null)
            {
                foreach (Curso curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int cont = 0;
            while (cont < arregloCursos.Length)
            {
                WriteLine($"Nombre: {arregloCursos[cont].Nombre}, Id: {arregloCursos[cont].UniqueId}");
                cont++;
            }
        }
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int cont = 0;
            do
            {
                WriteLine($"Nombre: {arregloCursos[cont].Nombre}, Id: {arregloCursos[cont].UniqueId}");
                cont++;
            } while (cont < arregloCursos.Length);
        }
        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                WriteLine($"Nombre: {arregloCursos[i].Nombre}, Id: {arregloCursos[i].UniqueId}");
            }
        }
        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (Curso curso in arregloCursos)
            {
                WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
            }
        }
    }
}