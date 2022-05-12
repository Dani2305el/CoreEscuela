using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
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
            CargarEvaluaciones();
        }
        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, bool impEval = false)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());

                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (impEval)
                            {
                                Console.WriteLine(val);
                            }
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: " + val);
                            break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + val.Nombre);
                            break;
                        case LlaveDiccionario.Curso:
                            var curTemp = val as Curso;
                            if (curTemp != null)
                            {
                                int count = curTemp.Alumnos.Count;
                                Console.WriteLine("Curso: " + val.Nombre + " Cantidad alumnos " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            dic.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            dic.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listTempEv = new List<Evaluacion>();
            var listTempAsign = new List<Asignatura>();
            var listTempAlum = new List<Alumno>();
            foreach (var cur in Escuela.Cursos)
            {
                listTempAsign.AddRange(cur.Asignaturas);
                listTempAlum.AddRange(cur.Alumnos);

                foreach (var alum in cur.Alumnos)
                {
                    listTempEv.AddRange(alum.Evaluaciones);
                }
            }
            dic.Add(LlaveDiccionario.Asignatura, listTempAsign.Cast<ObjetoEscuelaBase>());
            dic.Add(LlaveDiccionario.Alumno, listTempAlum.Cast<ObjetoEscuelaBase>());
            dic.Add(LlaveDiccionario.Evaluacion, listTempEv.Cast<ObjetoEscuelaBase>());
            return dic;
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(bool traeEvaluaciones = true, bool traeAlumnos = true,
                                                        bool traeAsignaturas = true, bool traeCursos = true
                                                        )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, bool traeEvaluaciones = true,
                                                        bool traeAlumnos = true,
                                                        bool traeAsignaturas = true, bool traeCursos = true
                                                        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, out int conteoCursos,
                                                        bool traeEvaluaciones = true, bool traeAlumnos = true,
                                                        bool traeAsignaturas = true, bool traeCursos = true
                                                        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, out int conteoCursos,
                                                        out int conteoAsignaturas, bool traeEvaluaciones = true, bool traeAlumnos = true,
                                                        bool traeAsignaturas = true, bool traeCursos = true
                                                        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones,
                                                        out int conteoCursos,
                                                        out int conteoAsignaturas,
                                                        out int conteoAlumnos,
                                                        bool traeEvaluaciones = true, bool traeAlumnos = true,
                                                        bool traeAsignaturas = true, bool traeCursos = true
                                                        )

        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            List<ObjetoEscuelaBase> listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if (traeCursos)
            {
                listaObj.AddRange(Escuela.Cursos);
            }

            conteoCursos = Escuela.Cursos.Count;

            foreach (Curso c in Escuela.Cursos)
            {
                conteoAsignaturas += c.Asignaturas.Count;
                conteoAlumnos += c.Alumnos.Count;

                if (traeAsignaturas)
                {
                    listaObj.AddRange(c.Asignaturas);
                }

                if (traeAlumnos)
                {
                    listaObj.AddRange(c.Alumnos);
                }
                if (traeEvaluaciones)
                {
                    foreach (Alumno a in c.Alumnos)
                    {
                        listaObj.AddRange(a.Evaluaciones);
                        conteoEvaluaciones += a.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }

        #region Métodos de carga
        private void CargarEvaluaciones()
        {
            Random random = new Random();
            foreach (Curso curso in Escuela.Cursos)
            {
                foreach (Asignatura asignatura in curso.Asignaturas)
                {
                    foreach (Alumno alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Evaluacion ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = MathF.Round(5 * (float)random.NextDouble(),2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
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
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
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
            foreach (Curso c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
    #endregion
}