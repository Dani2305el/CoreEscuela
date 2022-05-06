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

            MiEscuela.Cursos = new List<Curso>(){
                        new Curso{Nombre = "101",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "201",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301",Jornada = TiposJornada.Mañana}
            };
            MiEscuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            MiEscuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            List<Curso> otraColeccion = new List<Curso>(){
                        new Curso{Nombre = "402",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "501",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "501",Jornada = TiposJornada.Tarde}
            };
            /*
            MiEscuela.Cursos.AddRange(otraColeccion);
            ImprimirCursosEscuela(MiEscuela);

            MiEscuela.Cursos.RemoveAll(delegate (Curso cur)
            {
                return cur.Nombre == "301";
            });
            
            MiEscuela.Cursos.RemoveAll((cur)=>cur.Nombre == "501" && cur.Jornada == TiposJornada.Mañana);
            */
            ImprimirCursosEscuela(MiEscuela);
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