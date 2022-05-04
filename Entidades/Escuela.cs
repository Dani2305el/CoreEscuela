namespace CoreEscuela.Entidades{
    class Escuela{
        string nombre;
        public string Nombre{
            get{return nombre;}
            set{nombre = value;}
        }
        public int AnioCreacion{get;set;}
        public string Pais { get; set; }
        public string Cuidad { get; set; }

        /*Constructor tradicional
        public Escuela(string nombre,int anioCreacion){
            this.nombre = nombre;
            AnioCreacion = anioCreacion;
        }*/
        
        /*Constructor reducido*/
        public Escuela(string nombre,int anioCreacion)=>(Nombre,AnioCreacion) = (nombre,anioCreacion);
    }
}