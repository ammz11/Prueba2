namespace ObligatorioP2
{
    /// <summary>
    /// Representa una evidencia física encontrada en la escena del crimen (ADN, huellas, objetos, etc.).
    /// La presencia de huellas del sospechoso es un factor muy importante en este tipo de evidencia.
    /// </summary>
    public class EvidenciaFisica : Evidencia
    {
        // Indica si la evidencia contiene huellas o marcas genéticas del sospechoso
        // Esto es crucial: si es verdadero, suma 40 puntos adicionales al peso total
        private bool _tieneHuellasSospechoso;

        /// <summary>Obtiene o establece si la evidencia contiene huellas del sospechoso</summary>
        public bool TieneHuellasSospechoso
        {
            get { return _tieneHuellasSospechoso; }
            set { _tieneHuellasSospechoso = value; }
        }

        /// <summary>
        /// Constructor que inicializa una evidencia física.
        /// </summary>
        /// <param name="fechaRecoleccion">Fecha en que fue recolectada la evidencia</param>
        /// <param name="descripcion">Descripción detallada (ejemplo: "Muestra de ADN", "Huella digital")</param>
        /// <param name="tieneHuellasSospechoso">Si la evidencia contiene huellas/ADN del sospechoso</param>
        public EvidenciaFisica(DateTime fechaRecoleccion, string descripcion, bool tieneHuellasSospechoso)
            : base(fechaRecoleccion, descripcion)
        {
            _tieneHuellasSospechoso = tieneHuellasSospechoso;
        }

        /// <summary>
        /// Valida que los datos de la evidencia física sean correctos.
        /// Llama a la validación de la clase base.
        /// </summary>
        public override void Validar()
        {
            base.Validar();
        }

        /// <summary>
        /// Calcula el peso de una evidencia física según estos criterios:
        /// 1. Antigüedad: +5 puntos si fue recolectada hace menos de 6 meses, +3 si es más antigua
        /// 2. Huellas del sospechoso: +40 puntos si contiene huellas/ADN del sospechoso
        /// 
        /// Ejemplo de cálculo:
        /// - Evidencia reciente sin huellas = 5 puntos
        /// - Evidencia reciente con huellas = 45 puntos
        /// - Evidencia antigua con huellas = 43 puntos
        /// </summary>
        /// <returns>Peso total de la evidencia física</returns>
        public override int CalcularPeso()
        {
            int peso = 0;

            // Suma 5 puntos si fue recolectada hace menos de 6 meses (180 días), 3 si es más antigua
            TimeSpan diferencia = DateTime.Now - FechaRecoleccion;
            if (diferencia.TotalDays < 180)
            {
                peso += 5;
            }
            else
            {
                peso += 3;
            }

            // Si tiene huellas del sospechoso suma 40 puntos adicionales
            // Esto es lo más importante en evidencia física
            if (_tieneHuellasSospechoso)
            {
                peso += 40;
            }

            return peso;
        }

        /// <summary>Retorna una representación en texto de la evidencia física con sus datos principales</summary>
        public override string ToString()
        {
            return $"EvidenciaFísica [Id: {Id}, Huellas: {_tieneHuellasSospechoso}, Descripción: {Descripcion}]";
        }
    }
}
