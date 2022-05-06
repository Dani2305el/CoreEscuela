using CoreEscuela.Entidades;
namespace Etapa1{
    class Program{
        static void Main(string[]args){

            Escuela MiEscuela = new Escuela("Platzi Academy",2012, TiposEscuela.Primaria,
                pais:"Colombia",ciudad:"Bogota");

            Curso[] arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso(){
                                Nombre="102"
                            };

            Curso Curso2 = new Curso(){
                Nombre="201"
            };
            arregloCursos[1] = Curso2;

            arregloCursos[2] = new Curso{
                                Nombre="302"
                            };

            Console.WriteLine(MiEscuela);
            Console.WriteLine("============");
            
            ImprimirCursos(arregloCursos);

        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int cont = 0;
            while (cont<arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[cont].Nombre}, Id: {arregloCursos[cont].UniqueId}");
                cont++;
            }
        }
    }
}