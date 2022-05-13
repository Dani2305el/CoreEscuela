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

            int opcion;
            Console.WriteLine("1-Listar evaluaciones");
            Console.WriteLine("2-Listar asignaturas");
            Console.WriteLine("3-Listar evaluaciones por asignatura");
            Console.WriteLine("4-Listar promedios por asignatura");
            Console.WriteLine("5-Listar top de promedios por asignatura");
            Console.WriteLine("Ingrese una opción");

            opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Printer.WriteTitle("Lista de evaluaciones");
                    ListarEvaluaciones(evalList);
                    break;
                case 2:
                    Printer.WriteTitle("Lista de asignaturas");
                    ListarAsignaturas(listaAsign);
                    break;
                case 3:
                    Printer.WriteTitle("Lista de evaluaciones por asignatura");
                    ListarEvaluacionesXAsignatura(listaEvalXAsign);
                    break;
                case 4:
                    Printer.WriteTitle("Lista de promedios por asignatura");
                    ListarPromediosXAsignatura(listaPromXAsig);
                    break;
                case 5:
                    Printer.WriteTitle("Lista del top de promedios por asignatura");
                    ListarTopPromedios(topPromedio);
                    break;
                default:
                    Printer.WriteTitle("Ingrese una opción correcta");
                    break;
            }

            /* Printer.WriteTitle("Captura de una Evaluación por Consola");
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
            } */

        }

        private static void ListarTopPromedios(Dictionary<string, IEnumerable<AlumnoPromedio>> topPromedio)
        {
            foreach (var item in topPromedio)
            {
                Printer.WriteTitle(item.Key);
                foreach (var it in item.Value)
                {
                    WriteLine(it);
                }
            }
        }

        private static void ListarPromediosXAsignatura(Dictionary<string, IEnumerable<object>> listaPromXAsig)
        {
            foreach (var asign in listaPromXAsig)
            {
                Printer.WriteTitle(asign.Key);
                foreach (var prom in asign.Value)
                {
                    WriteLine(prom.ToString());
                }
            }
        }

        private static void ListarEvaluacionesXAsignatura(Dictionary<string, IEnumerable<Evaluacion>> listaEvalXAsign)
        {
            foreach (var item in listaEvalXAsign)
            {
                Printer.WriteTitle(item.Key);
                foreach (var value in item.Value)
                {
                   WriteLine(value);
                }
            }
        }

        private static void ListarAsignaturas(IEnumerable<string> listaAsign)
        {
            foreach (var item in listaAsign)
            {
                WriteLine(item);
            }
        }

        private static void ListarEvaluaciones(IEnumerable<Evaluacion> evalList)
        {
            foreach (var item in evalList)
            {
                WriteLine(item);
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