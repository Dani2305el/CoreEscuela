using CoreEscuela.Entidades;
namespace Etapa1{
    class Program{
        static void Main(string[]args){
            Escuela MiEscuela = new Escuela("Platzi Academy",2012);
            MiEscuela.Pais = "Colombia";
            MiEscuela.Cuidad = "Bogota";
            MiEscuela.TipoEscuela = TiposEscuela.Primaria;
     
            Console.WriteLine(MiEscuela);
            
        }
    }
}