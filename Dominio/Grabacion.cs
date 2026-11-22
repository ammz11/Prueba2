namespace ObligatorioP2
{
    /// <summary>
    /// Representa una grabación de video o audio de una cámara de vigilancia.
    /// Es especialmente importante si captura al sospechoso en el acto del delito ("infraganti").
    /// </summary>
    public class Grabacion : Evidencia
    {
        // Calidad de la grabación: debe estar entre 1 (mala) y 5 (excelente)
        private int _calidad;

        // Indica si la grabación captura al sospechoso cometiendo el delito en flagrancia
        // Si es verdadero, suma 60 puntos (muy importante para la investigación)
        private bool _capturaInfraganti;

        /// <summary>Obtiene o establece la calidad de la grabación (1-5, donde 5 es la mejor)</summary>
        public int Calidad
        {
            get { return _calidad; }
            set { _calidad = value; }
        }

        /// <summary>Obtiene o establece si la grabación captura al sospechoso en flagrancia</summary>
        public bool CapturaInfraganti
        {
            get { return _capturaInfraganti; }
            set { _capturaInfraganti = value; }
        }

        /// <summary>
        /// Constructor que inicializa una grabación de video/audio.
        /// </summary>
        /// <param name="fechaRecoleccion">Fecha en que fue registrada la grabación</param>
        /// <param name="descripcion">Descripción de lo que muestra la grabación</param>
        /// <param name="calidad">Calidad de la grabación (1-5)</param>
        /// <param name="capturaInfraganti">Si registra al sospechoso cometiendo el delito</param>
        public Grabacion(DateTime fechaRecoleccion, string descripcion, int calidad, bool capturaInfraganti)
            : base(fechaRecoleccion, descripcion)
        {
            _calidad = calidad;
            _capturaInfraganti = capturaInfraganti;
        }

        /// <summary>
        /// Valida que los datos de la grabación sean correctos.
        /// Reglas de validación:
        /// - Llama a la validación de la clase base
        /// - La calidad debe estar entre 1 y 5
        /// </summary>
        /// <exception cref="Exception">Si la calidad está fuera del rango permitido</exception>
        public override void Validar()
        {
            base.Validar();

            if (_calidad < 1 || _calidad > 5)
            {
                throw new Exception("La calidad debe estar entre 1 y 5");
            }
        }

        /// <summary>
        /// Calcula el peso de una grabación según estos criterios:
        /// 1. Antigüedad: +5 puntos si fue recolectada hace menos de 6 meses, +3 si es más antigua
        /// 2. Captura en infraganti: +60 puntos si registra al sospechoso cometiendo el delito
        /// 3. Calidad si es infraganti: +10 puntos adicionales si la calidad es >= 3
        /// 
        /// Ejemplo de cálculo:
        /// - Grabación antigua no infraganti = 3 puntos
        /// - Grabación reciente infraganti calidad 2 = 65 puntos (5+60)
        /// - Grabación reciente infraganti calidad 4 = 75 puntos (5+60+10)
        /// </summary>
        /// <returns>Peso total de la grabación</returns>
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

            // Si es una grabación que registra al sospechoso en infraganti suma 60 puntos
            if (_capturaInfraganti)
            {
                peso += 60;

                // Si la calidad es >= 3 suma 10 puntos adicionales
                if (_calidad >= 3)
                {
                    peso += 10;
                }
            }

            return peso;
        }

        /// <summary>Retorna una representación en texto de la grabación con sus datos principales</summary>
        public override string ToString()
        {
            return $"Grabación [Id: {Id}, Infraganti: {_capturaInfraganti}, Descrissspción: {Descripcion}]";
        }
    }
}
