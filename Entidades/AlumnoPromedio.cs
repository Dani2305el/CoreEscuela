namespace CoreEscuela.Entidades{
    public class AlumnoPromedio{
        public float promedio;
        public string alumnoId;
        public string alumnoNombre;

        public override string ToString()
        {
            return $"Alumno: {alumnoNombre} Promedio: {promedio}";
        }
    }
}