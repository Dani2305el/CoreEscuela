using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela:ObjetoEscuelaBase, ILugar
    {
        public int AnioCreacion { get; set; }
        public string Pais { get; set; }
        public string Cuidad { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos{get;set;}

        /*Constructor reducido*/
        public Escuela(string nombre, int anioCreacion) => (Nombre, AnioCreacion) = (nombre, anioCreacion);

        /*Constructor tradicional*/ //con parametros opcionales
        public Escuela(string nombre, int anioCreacion,
            TiposEscuela tipoEscuela, string pais = "", string ciudad = "")
        {
            //asignacion por tuplas
            (Nombre, AnioCreacion) = (nombre, anioCreacion);
            Pais = pais;
            Cuidad = ciudad;
        }
        public override string ToString()
        {
            //para saltos de linea \n o System.Environment.NewLine()
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela}\nPais: {Pais}, Ciudad: {Cuidad}";
        }
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            foreach (Curso c in Cursos)
            {
                c.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre}Limpiando limpia");
        }
    }
}