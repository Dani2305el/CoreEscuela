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
            EscuelaEngine Engine = new EscuelaEngine();
            Engine.Inicializar();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000,cantidad:3);
            ImprimirCursosEscuela(Engine.Escuela);
            List<ObjetoEscuelaBase> listaObjetos = Engine.GetObjetosEscuela();

            IEnumerable listaILugar = from obj in listaObjetos
                                where obj is ILugar
                                select (ILugar) obj;
            //Engine.Escuela.LimpiarLugar();
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