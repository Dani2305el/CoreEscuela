using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;
namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            EscuelaEngine Engine = new EscuelaEngine();
            Engine.Inicializar();
            
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000,cantidad:3);
            ImprimirCursosEscuela(Engine.Escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de polimorfismo");
            Alumno test = new Alumno{Nombre = "Alvaro"};

            ObjetoEscuelaBase ob = test;
            
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {test.Nombre}");
            WriteLine($"Alumno: {test.UniqueId}");
            WriteLine($"Alumno: {test.GetType()}");
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            ObjetoEscuelaBase dummy = new ObjetoEscuelaBase(){Nombre="Frank"};
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"Alumno: {dummy.Nombre}");
            WriteLine($"Alumno: {dummy.UniqueId}");
            WriteLine($"Alumno: {dummy.GetType()}");
        }
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la escuela");

            if (escuela?.Cursos != null)
            {
                foreach (Curso curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }
    }
}