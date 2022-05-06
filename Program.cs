using CoreEscuela.Entidades;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {

            Escuela MiEscuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                pais: "Colombia", ciudad: "Bogota");

            Curso[] arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "102"
            };

            Curso Curso2 = new Curso()
            {
                Nombre = "201"
            };
            arregloCursos[1] = Curso2;

            arregloCursos[2] = new Curso
            {
                Nombre = "302"
            };

            Console.WriteLine(MiEscuela);
            Console.WriteLine("============");

            ImprimirCursosWhile(arregloCursos);
            Console.WriteLine("============");
            ImprimirCursosDoWhile(arregloCursos);
            Console.WriteLine("============");
            ImprimirCursosFor(arregloCursos);
            Console.WriteLine("============");
            ImprimirCursosForEach(arregloCursos);
           

        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int cont = 0;
            while (cont < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[cont].Nombre}, Id: {arregloCursos[cont].UniqueId}");
                cont++;
            }
        }
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int cont = 0;
            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[cont].Nombre}, Id: {arregloCursos[cont].UniqueId}");
                cont++;
            } while (cont < arregloCursos.Length);
        }
        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre: {arregloCursos[i].Nombre}, Id: {arregloCursos[i].UniqueId}");
            }
        }
        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (Curso curso in arregloCursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
            }
        }
    }
}