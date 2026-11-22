namespace ObligatorioP2
{
    /// <summary>
    /// Representa a un investigador (Detective o Fiscal) del sistema de fiscalía.
    /// Almacena las credenciales y datos técnicos del usuario.
    /// </summary>
    public class Investigador
    {
        // Email único del investigador para acceso al sistema
        private string _email;

        // Contraseña del investigador para autenticación
        private string _contrasena;

        // Nombre completo del investigador
        private string _nombre;

        // Rol del investigador: DETECTIVE o FISCAL (ver enum Rol)
        private Rol _rol;

        /// <summary>Obtiene o establece el email del investigador</summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>Obtiene o establece la contraseña del investigador</summary>
        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        /// <summary>Obtiene o establece el nombre completo del investigador</summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>Obtiene o establece el rol del investigador (DETECTIVE o FISCAL)</summary>
        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        /// <summary>
        /// Constructor que inicializa un nuevo investigador con todos sus datos.
        /// </summary>
        /// <param name="email">Email único del investigador</param>
        /// <param name="contrasena">Contraseña del investigador</param>
        /// <param name="nombre">Nombre completo del investigador</param>
        /// <param name="rol">Rol del investigador (DETECTIVE o FISCAL)</param>
        public Investigador(string email, string contrasena, string nombre, Rol rol)
        {
            _email = email;
            _contrasena = contrasena;
            _nombre = nombre;
            _rol = rol;
        }

        /// <summary>
        /// Valida que los datos del investigador sean correctos.
        /// Reglas de validación:
        /// - El email no puede estar vacío
        /// - La contraseña no puede estar vacía
        /// - El nombre no puede estar vacío
        /// </summary>
        /// <exception cref="Exception">Si alguno de los datos no es válido</exception>
        public void Validar()
        {
            if (string.IsNullOrEmpty(_email))
            {
                throw new Exception("El email no puede estar vacío");
            }

            if (string.IsNullOrEmpty(_contrasena))
            {
                throw new Exception("La contraseña no puede estar vacía");
            }

            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }
        }

        /// <summary>Retorna una representación en texto del investigador con sus datos principales</summary>
        public override string ToString()
        {
            return $"Investigador [Email: {_email}, Nombre: {_nombre}, Rol: {_rol}]";
        }
    }
}
