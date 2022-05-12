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

        public IEnumerable<Escuela> GetListaEvaluacions()
        {
            IEnumerable<Escuela> res = null;
            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                res = lista.Cast<Escuela>();
            }

           return res;
            
        }
    }
}