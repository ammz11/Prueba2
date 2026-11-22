namespace ObligatorioP2
{
    /// <summary>
    /// Representa un caso penal completo con sus evidencias, investigadores y sospechosos.
    /// Es la clase central del sistema que agrupa toda la información de una investigación.
    /// 
    /// El sistema calcula automáticamente un "peso" (0-100) basado en las evidencias para
    /// recomendar si el caso debe ser desestimado, continuar investigándose o proceder a imputación.
    /// </summary>
    public class Caso
    {
        // Contador estático para generar IDs únicos automáticamente
        private static int _proximoId = 1;

        // ID único del caso
        private int _id;

        // Nombre del caso (ejemplo: "Robo a Comercio", "Homicidio Doloso")
        private string _nombre;

        // Descripción detallada de los hechos del caso
        private string _descripcion;

        // Indica si el caso está cerrado (investigación completa) o abierto
        private bool _estaCerrado;

        // Sospechoso principal del caso
        private Sospechoso _sospechosoPrincipal;

        // Detective investigador asignado al caso (debe tener rol DETECTIVE)
        private Investigador _detective;

        // Lista de todas las evidencias recolectadas en el caso
        private List<Evidencia> _evidencias;

        /// <summary>Obtiene el ID único del caso (propiedad de solo lectura)</summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>Obtiene o establece el nombre del caso</summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>Obtiene o establece la descripción del caso</summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>Obtiene o establece si el caso está cerrado</summary>
        public bool EstaCerrado
        {
            get { return _estaCerrado; }
            set { _estaCerrado = value; }
        }

        /// <summary>Obtiene o establece el sospechoso principal del caso</summary>
        public Sospechoso SospechosoPrincipal
        {
            get { return _sospechosoPrincipal; }
            set { _sospechosoPrincipal = value; }
        }

        /// <summary>Obtiene o establece el detective investigador del caso</summary>
        public Investigador Detective
        {
            get { return _detective; }
            set { _detective = value; }
        }

        /// <summary>Obtiene una copia de la lista de evidencias del caso (propiedad de solo lectura)</summary>
        public List<Evidencia> Evidencias
        {
            get { return new List<Evidencia>(_evidencias); }
        }

        /// <summary>
        /// Constructor que inicializa un nuevo caso.
        /// </summary>
        /// <param name="nombre">Nombre del caso</param>
        /// <param name="descripcion">Descripción detallada de los hechos</param>
        /// <param name="sospechosoPrincipal">Sospechoso investigado</param>
        /// <param name="detective">Detective asignado (debe tener rol DETECTIVE)</param>
        public Caso(string nombre, string descripcion, Sospechoso sospechosoPrincipal, Investigador detective)
        {
            // Asignamos un ID único y lo incrementamos para el próximo caso
            _id = _proximoId;
            _proximoId++;
            _nombre = nombre;
            _descripcion = descripcion;
            _estaCerrado = false; // Los casos inician abiertos
            _sospechosoPrincipal = sospechosoPrincipal;
            _detective = detective;
            _evidencias = new List<Evidencia>();
        }

        /// <summary>
        /// Valida que los datos del caso sean correctos antes de ser guardado.
        /// Reglas de validación:
        /// - El nombre no puede estar vacío
        /// - La descripción no puede estar vacía
        /// - El sospechoso no puede ser nulo
        /// - El detective no puede ser nulo
        /// - El detective DEBE tener rol DETECTIVE (no FISCAL)
        /// </summary>
        /// <exception cref="Exception">Si alguno de los datos no es válido</exception>
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre del caso no puede estar vacío");
            }

            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception("La descripción no puede estar vacía");
            }

           if (_sospechosoPrincipal == null)
           {
               throw new Exception("El sospechoso principal no puede ser nulo");
           }

            if (_detective == null)
            {
                throw new Exception("El detective no puede ser nulo");
            }

            if (_detective.Rol != Rol.DETECTIVE)
            {
                throw new Exception("El investigador debe tener rol DETECTIVE");
            }
        }

        /// <summary>
        /// Añade una evidencia al caso después de validarla.
        /// </summary>
        /// <param name="evidencia">Evidencia a agregar (puede ser física, grabación, testimonio, etc.)</param>
        /// <exception cref="Exception">Si la evidencia es nula o no pasa validación</exception>
        public void AgregarEvidencia(Evidencia evidencia)
        {
            if (evidencia == null)
            {
                throw new Exception("La evidencia no puede ser nula");
            }

            // Valida la evidencia antes de agregarla
            evidencia.Validar();
            _evidencias.Add(evidencia);
        }

        /// <summary>
        /// Calcula el peso total del caso (0-100) sumando el peso de todas las evidencias.
        /// 
        /// FÓRMULA DE CÁLCULO:
        /// 1. Se suma el peso de cada evidencia según su tipo y características
        /// 2. Si el sospechoso tiene antecedentes, se suman 10 puntos adicionales
        /// 3. El peso total se limita a un máximo de 100 puntos
        /// 
        /// IMPORTANCIA: Este peso es fundamental para determinar la recomendación del caso.
        /// </summary>
        /// <returns>Peso total del caso entre 0 y 100</returns>
        public int CalcularPesoEvidencias()
        {
            int pesoTotal = 0;

            // Suma el peso de cada evidencia
            foreach (Evidencia evidencia in _evidencias)
            {
                pesoTotal += evidencia.CalcularPeso();
            }

            // Suma 10 puntos más si el sospechoso tiene antecedentes
            if (_sospechosoPrincipal.TieneAntecedentes)
            {
                pesoTotal += 10;
            }

            // El peso máximo es 100
            if (pesoTotal > 100)
            {
                pesoTotal = 100;
            }

            return pesoTotal;
        }

        /// <summary>
        /// Elabora una recomendación basada en el peso total del caso.
        /// 
        /// CRITERIOS:
        /// - Peso < 30: DESESTIMADO (insuficientes pruebas)
        /// - Peso 30-70: CONTINUAR INVESTIGANDO (hay indicios pero falta información)
        /// - Peso > 70: IMPUTACIÓN INMINENTE (pruebas suficientes para procesar)
        /// 
        /// Esta recomendación es fundamental para que el Fiscal tome decisiones.
        /// </summary>
        /// <returns>Texto con la recomendación y análisis del caso</returns>
        public string ElaborarRecomendacion()
        {
            int peso = CalcularPesoEvidencias();
            string recomendacion;

            if (peso < 30)
            {
                recomendacion = $"DESESTIMADO: El caso {_nombre} carece de fundamentos. El peso de la prueba es {peso} y debería ser desestimado finalizando la investigación en contra de {_sospechosoPrincipal.Nombre}.";
            }
            else if (peso >= 30 && peso <= 70)
            {
                recomendacion = $"CONTINUAR INVESTIGANDO: El caso \"{_nombre}\" parece ir por el camino correcto, pero necesita más investigación. El peso de la prueba es {peso} pero aún no hay información suficiente para imputar a {_sospechosoPrincipal.Nombre}.";
            }
            else // peso > 70
            {
                recomendacion = $"IMPUTACIÓN INMINENTE: El caso \"{_nombre}\" está resuelto. El peso de la prueba es {peso} y debería imputarse a {_sospechosoPrincipal.Nombre} inmediatamente.";
            }

            return recomendacion;
        }

        /// <summary>
        /// Verifica si un investigador específico está asignado como detective en este caso.
        /// </summary>
        /// <param name="investigador">Investigador a verificar</param>
        /// <returns>true si el investigador es el detective del caso, false en caso contrario</returns>
        public bool TieneAsignadoDetective(Investigador investigador)
        {
            return _detective == investigador;
        }

        /// <summary>
        /// Obtiene el nombre del detective asignado al caso.
        /// </summary>
        /// <returns>Nombre del detective</returns>
        public string ObtenerNombreDetective()
        {
            return _detective.Nombre;
        }

        /// <summary>
        /// Obtiene el nombre del sospechoso principal del caso.
        /// </summary>
        /// <returns>Nombre del sospechoso principal</returns>
        public string ObtenerNombreSospechosoPrincipal()
        {
            return _sospechosoPrincipal.Nombre;
        }

        /// <summary>Retorna una representación en texto del caso con sus datos principales</summary>
        public override string ToString()
        {
            return $"Caso [Id: {_id}, Nombre: {_nombre}, Cerrado: {_estaCerrado}, Evidencias: {_evidencias.Count}]";
        }
    }
}
