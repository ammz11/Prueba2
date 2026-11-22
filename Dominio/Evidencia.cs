namespace ObligatorioP2
{
    /// <summary>
    /// Clase abstracta que representa una evidencia genérica en una investigación.
    /// Las evidencias pueden ser de diferentes tipos: física, grabaciones, testimonios, etc.
    /// Cada tipo de evidencia calcula su peso de forma distinta según su naturaleza y fecha de recolección.
    /// </summary>
    public abstract class Evidencia
    {
        // Contador estático para generar IDs únicos automáticamente
        private static int _proximoId = 1;

        // ID único de la evidencia
        private int _id;

        // Fecha en que fue recolectada la evidencia
        private DateTime _fechaRecoleccion;

        // Descripción detallada de la evidencia
        private string _descripcion;

        /// <summary>Obtiene el ID único de la evidencia (propiedad de solo lectura)</summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>Obtiene o establece la fecha de recolección de la evidencia</summary>
        public DateTime FechaRecoleccion
        {
            get { return _fechaRecoleccion; }
            set { _fechaRecoleccion = value; }
        }

        /// <summary>Obtiene o establece la descripción de la evidencia</summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Constructor protegido que inicializa una evidencia con ID auto-incrementado.
        /// </summary>
        /// <param name="fechaRecoleccion">Fecha en que fue encontrada/recolectada la evidencia</param>
        /// <param name="descripcion">Descripción detallada de la evidencia</param>
        protected Evidencia(DateTime fechaRecoleccion, string descripcion)
        {
            // Asignamos un ID único y lo incrementamos para la próxima instancia
            _id = _proximoId;
            _proximoId++;
            _fechaRecoleccion = fechaRecoleccion;
            _descripcion = descripcion;
        }

        /// <summary>
        /// Valida que los datos de la evidencia sean correctos.
        /// Reglas de validación:
        /// - La fecha de recolección no puede ser posterior a hoy
        /// - La descripción no puede estar vacía
        /// Este método puede ser extendido por las clases derivadas.
        /// </summary>
        /// <exception cref="Exception">Si alguno de los datos no es válido</exception>
        public virtual void Validar()
        {
            if (_fechaRecoleccion.Date > DateTime.Now.Date)
            {
                throw new Exception("La fecha de recolección no puede ser superior a hoy");
            }

            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception("La descripción no puede estar vacía");
            }
        }

        /// <summary>
        /// Método abstracto que calcula el peso (importancia/credibilidad) de esta evidencia.
        /// Cada tipo de evidencia implementa su propio cálculo basado en diferentes factores.
        /// 
        /// Regla general: Si la evidencia tiene menos de 6 meses, suma 5 puntos. Si es más antigua, suma 3.
        /// 
        /// IMPORTANTE: El peso total del caso nunca excede 100 puntos.
        /// </summary>
        /// <returns>Puntos de peso de la evidencia</returns>
        public abstract int CalcularPeso();

        /// <summary>Retorna una representación en texto de la evidencia con sus datos principales</summary>
        public override string ToString()
        {
            return $"Evidencia [Id: {_id}, Fecha: {_fechaRecoleccion.ToShortDateString()}, Descripción: {_descripcion}]";
        }
    }
}
