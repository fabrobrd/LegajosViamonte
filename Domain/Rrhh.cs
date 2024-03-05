namespace Legajos.Domain
{
    public class Rrhh
    {

        protected Rrhh()
        {

        }

        public Rrhh(int legajo, string nombre, int nivel, string passwd, string code,
                    string doc_tipo, int doc_nro, string cuil, int if_activo,
                    int if_del, DateTime f_alta):this()
        {
            this.Legajo = legajo;
            this.Nombre = nombre;
            this.Nivel = nivel;
            this.Passwd = passwd;
            this.Code = code;
            this.Doc_Tipo = doc_tipo;
            this.Doc_Nro = doc_nro;
            this.Cuil = cuil;
            this.If_Activo = if_activo;
            this.If_Del = if_del;
            this.F_Alta = f_alta;
        }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public string Passwd { get; set; }
        public string Code { get; set; }
        public string Doc_Tipo { get; set; }
        public int Doc_Nro { get; set; }
        public string Cuil { get; set; }
        public int If_Activo { get; set; }
        public int If_Del { get; set; }
        public DateTime F_Alta { get; set; }

    }
}
