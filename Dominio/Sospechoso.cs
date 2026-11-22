namespace ObligatorioP2
{
    /// <summary>
    /// Representa a una persona sospechosa en una investigación penal.
    /// Almacena la información personal y el estado de antecedentes del sospechoso.
    /// </summary>
    public class Sospechoso
    {
        // Nombre completo del sospechoso
        private string _nombre;

        // Cédula de identidad única del sospechoso (formato uruguayo: 7 dígitos)
        private string _cedula;

        // Fecha de nacimiento del sospechoso
        private DateTime _fechaNacimiento;

        // Indica si el sospechoso tiene antecedentes penales
        // Importante: Si tiene antecedentes, se suma 10 puntos adicionales al peso de la prueba
        private bool _tieneAntecedentes;

        /// <summary>Obtiene o establece el nombre completo del sospechoso</summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>Obtiene o establece la cédula de identidad del sospechoso</summary>
        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        /// <summary>Obtiene o establece la fecha de nacimiento del sospechoso</summary>
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        /// <summary>Obtiene o establece si el sospechoso tiene antecedentes penales</summary>
        public bool TieneAntecedentes
        {
            get { return _tieneAntecedentes; }
            set { _tieneAntecedentes = value; }
        }

        /// <summary>
        /// Constructor que inicializa un nuevo sospechoso con todos sus datos.
        /// </summary>
        /// <param name="nombre">Nombre completo del sospechoso</param>
        /// <param name="cedula">Cédula de identidad (formato: 7 dígitos)</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento</param>
        /// <param name="tieneAntecedentes">Si tiene antecedentes penales</param>
        public Sospechoso(string nombre, string cedula, DateTime fechaNacimiento, bool tieneAntecedentes)
        {
            _nombre = nombre;
            _cedula = cedula;
            _fechaNacimiento = fechaNacimiento;
            _tieneAntecedentes = tieneAntecedentes;
        }

        /// <summary>
        /// Valida que los datos del sospechoso sean correctos.
        /// Reglas de validación:
        /// - El nombre no puede estar vacío
        /// - La cédula no puede estar vacía
        /// - La fecha de nacimiento no puede ser en el futuro
        /// </summary>
        /// <exception cref="Exception">Si alguno de los datos no es válido</exception>
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }

            if (string.IsNullOrEmpty(_cedula))
            {
                throw new Exception("La cédula no puede estar vacía");
            }

            if (_fechaNacimiento >= DateTime.Now)
            {
                throw new Exception("La fecha de nacimiento no puede ser en el futuro");
            }
        }

        /// <summary>Retorna una representación en texto del sospechoso con sus datos principales</summary>
        public override string ToString()
        {
            return $"Sospechoso [Nombre: {_nombre}, Cédula: {_cedula}, Antecedentes: {_tieneAntecedentes}]";
        }
    }
}
