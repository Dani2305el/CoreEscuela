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
            var listaEv = GetListaEvaluacions();

            return (from Evaluacion ev in listaEv select ev.Asignatura.Nombre).Distinct();   
        }
        public Dictionary<string,IEnumerable<Evaluacion>> getDicEvaluacionXAsign(){
             Dictionary<string,IEnumerable<Evaluacion>> resDic = new  Dictionary<string,IEnumerable<Evaluacion>> ();
             return resDic;
        }
    }
}