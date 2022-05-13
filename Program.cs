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
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

            EscuelaEngine Engine = new EscuelaEngine();
            Engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            Reporteador reporteador = new Reporteador(Engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluacions();
            var listaAsign = reporteador.GetListaAsignaturas();
            var listaEvalXAsign = reporteador.getDicEvaluacionXAsign();
            var listaPromXAsig = reporteador.getPromedioAlumnXAsignatura();
            var topPromedio = reporteador.GetListaTopPromedio(2);

            Printer.WriteTitle("Captura de una Evaluación por Consola");
            Evaluacion newEval = new Evaluacion();
            float nota;
            string nombre,notaString;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(notaString))
            {
                Printer.WriteTitle("El valor de la nota no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString); 
                    if(newEval.Nota<0 || newEval.Nota>5){
                        throw new ArgumentOutOfRangeException("La nota debe star entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido ingresada correctamente");
                }
                catch(ArgumentOutOfRangeException arge){
                    Printer.WriteTitle(arge.Message);
                }
                catch(Exception)
                { 
                    Printer.WriteTitle("El valor de la nota no es un número válido");
                    WriteLine("Saliendo del programa");
                }
                finally{
                    Printer.WriteTitle("Finally");
                    Printer.Beep(2500,500,3);
                }
            }

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
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