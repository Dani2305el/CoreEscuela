using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }
        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                pais: "Colombia", ciudad: "Bogota");

            CargarCursos();
            CargarAsignaturas();
           ///CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (Curso curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{Nombre = $"{n1} {n2} {a1}"};
            return listaAlumnos.OrderBy((al)=>al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso{Nombre = "101",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "201",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "401",Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "501",Jornada = TiposJornada.Mañana},
            };
            Random rnd = new Random();
            foreach(Curso c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5,20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
}