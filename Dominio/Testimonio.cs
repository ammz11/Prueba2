namespace ObligatorioP2
{
    /// <summary>
    /// Representa un testimonio de una persona que presenció o tiene conocimiento del delito.
    /// El peso del testimonio depende de la credibilidad del testigo.
    /// </summary>
    public class Testimonio : Evidencia
    {
        // Nombre completo de la persona que brinda el testimonio
        private string _nombreTestigo;

        // Nivel de credibilidad del testigo: BAJO, MEDIO o ALTO
        // Afecta directamente el peso que se asigna al testimonio
        private Credibilidad _credibilidad;

        /// <summary>Obtiene o establece el nombre del testigo</summary>
        public string NombreTestigo
        {
            get { return _nombreTestigo; }
            set { _nombreTestigo = value; }
        }

        /// <summary>Obtiene o establece el nivel de credibilidad del testigo (BAJO, MEDIO o ALTO)</summary>
        public Credibilidad Credibilidad
        {
            get { return _credibilidad; }
            set { _credibilidad = value; }
        }

        /// <summary>
        /// Constructor que inicializa un testimonio.
        /// </summary>
        /// <param name="fechaRecoleccion">Fecha en que fue tomado el testimonio</param>
        /// <param name="descripcion">Descripción de lo que declaró el testigo</param>
        /// <param name="nombreTestigo">Nombre completo del testigo</param>
        /// <param name="credibilidad">Nivel de credibilidad: BAJO, MEDIO o ALTO</param>
        public Testimonio(DateTime fechaRecoleccion, string descripcion, string nombreTestigo, Credibilidad credibilidad)
            : base(fechaRecoleccion, descripcion)
        {
            _nombreTestigo = nombreTestigo;
            _credibilidad = credibilidad;
        }

        /// <summary>
        /// Valida que los datos del testimonio sean correctos.
        /// Reglas de validación:
        /// - Llama a la validación de la clase base
        /// - El nombre del testigo no puede estar vacío
        /// </summary>
        /// <exception cref="Exception">Si el nombre del testigo está vacío</exception>
        public override void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(_nombreTestigo))
            {
                throw new Exception("El nombre del testigo no puede estar vacío");
            }
        }

        /// <summary>
        /// Calcula el peso de un testimonio según estos criterios:
        /// 1. Antigüedad: +5 puntos si fue recolectada hace menos de 6 meses, +3 si es más antigua
        /// 2. Credibilidad: +10 puntos adicionales si la credibilidad es MEDIO o ALTO
        /// 
        /// Ejemplo de cálculo:
        /// - Testimonio reciente, credibilidad BAJO = 5 puntos
        /// - Testimonio reciente, credibilidad MEDIO = 15 puntos (5+10)
        /// - Testimonio antiguo, credibilidad ALTO = 13 puntos (3+10)
        /// </summary>
        /// <returns>Peso total del testimonio</returns>
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

            // Si el índice de credibilidad es MEDIO O ALTO suma 10 puntos
            if (_credibilidad == Credibilidad.MEDIO || _credibilidad == Credibilidad.ALTO)
            {
                peso += 10;
            }

            return peso;
        }

        /// <summary>Retorna una representación en texto del testimonio con sus datos principales</summary>
        public override string ToString()
        {
            return $"Testimonio [Id: {Id}, Testigo: {_nombreTestigo}, Credibilidad: {_credibilidad}, Descripción: {Descripcion}]";
        }
    }
}
