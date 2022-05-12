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

            Dictionary<int,string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"Juank");
            diccionario.Add(23,"Lorem ipsum");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }
            Printer.WriteTitle("Accedo a Diccionario");
            diccionario[0] = "alvaro";
            WriteLine(diccionario[0]);

            Printer.WriteTitle("Otro diccionario");
            Dictionary<string,string> dic = new Dictionary<string,string>();
            dic["luna"] = "Cuerpo celeste que gira alrededor de la tierra";
            WriteLine(dic["luna"]);
            dic["luna"] = "Protagonista de soy luna";
            WriteLine(dic["luna"]);
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