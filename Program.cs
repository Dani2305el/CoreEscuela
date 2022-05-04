using CoreEscuela.Entidades;
namespace Etapa1{
    class Program{
        static void Main(string[]args){
            Escuela MiEscuela = new Escuela("Platzi Academy",2012);

            Console.WriteLine(MiEscuela.Nombre);
            Console.WriteLine(MiEscuela.AnioCreacion);
        }
    }
}