using System.Collections;
using System.Collections.Generic;
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
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o,s)=>Printer.Beep(2000,1000,1);

            EscuelaEngine Engine = new EscuelaEngine();
            Engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            Reporteador reporteador = new Reporteador(Engine.GetDiccionarioObjetos());
            reporteador.GetListaEvaluacions();
            
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000,1000,3);
            Printer.WriteTitle("SALIÓ");
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