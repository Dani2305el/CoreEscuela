using CoreEscuela.Entidades;
using System.Linq;
namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjsEscuela)
        {
            if (dicObjsEscuela == null)
            {
                throw new ArgumentException(nameof(dicObjsEscuela));
            }
            _diccionario = dicObjsEscuela;
        }

        public IEnumerable<Evaluacion> GetListaEvaluacions()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }
         public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);   
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion>  listaEv)
        {
            listaEv = GetListaEvaluacions();

            return (from Evaluacion ev in listaEv select ev.Asignatura.Nombre).Distinct();   
        }
        public Dictionary<string,IEnumerable<Evaluacion>> getDicEvaluacionXAsign(){
             
             Dictionary<string,IEnumerable<Evaluacion>> resDic = new  Dictionary<string,IEnumerable<Evaluacion>> ();
             
             var listaAsign = GetListaAsignaturas(out var listaEv);
             foreach (var asign in listaAsign)
             {
                 var evalsAsign = from eval in listaEv where eval.Asignatura.Nombre == asign select eval;
                 resDic.Add(asign,evalsAsign);
             }

             return resDic;
        }
        public Dictionary<string,IEnumerable<object>> getPromedioAlumnXAsignatura(){
            var res = new Dictionary<string,IEnumerable<object>>();
            var dicEvalXAsign = getDicEvaluacionXAsign();

            foreach (var asignConEval in dicEvalXAsign)
            {
                var dummy = from eval in asignConEval.Value 
                select new {
                    eval.Alumno.UniqueId,
                    NombreAlumno = eval.Alumno.Nombre,
                    NombreEval = eval.Nombre,
                    eval.Nota
                };
            }
            return res;
        }
    }
}