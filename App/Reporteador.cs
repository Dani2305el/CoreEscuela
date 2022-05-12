using CoreEscuela.Entidades;

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
            return _diccionario[LlaveDiccionario.Evaluacion];
        }
    }
}