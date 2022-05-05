using CoreEscuela.Entidades;
namespace Etapa1{
    class Program{
        static void Main(string[]args){
            Escuela MiEscuela = new Escuela("Platzi Academy",2012, TiposEscuela.Primaria,
                pais:"Colombia",ciudad:"Bogota");

            Curso Curso1 = new Curso(){
                Nombre="102"
            };
            Curso Curso2 = new Curso(){
                Nombre="201"
            };
            Curso Curso3 = new Curso(){
                Nombre="302"
            };


            Console.WriteLine(MiEscuela);
            Console.WriteLine("============");
            Console.WriteLine($"{Curso1.Nombre}, {Curso1.UniqueId}");
            Console.WriteLine($"{Curso2.Nombre}, {Curso2.UniqueId}");
            Console.WriteLine($"{Curso3.Nombre}, {Curso3.UniqueId}");
        }
    }
}