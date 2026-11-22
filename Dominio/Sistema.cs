namespace ObligatorioP2
{
    /// <summary>
    /// Clase central que gestiona todo el sistema de fiscalía.
    /// Almacena investigadores, sospechosos y casos. Proporciona métodos para buscar y crear nuevos registros.
    /// 
    /// El sistema se precarga automáticamente con datos de prueba cuando se inicializa.
    /// </summary>
    public class Sistema
    {
        // Lista de todos los investigadores del sistema (Detectives y Fiscales)
        private List<Investigador> _investigadores;

        // Lista de todos los sospechosos registrados en el sistema
        private List<Sospechoso> _sospechosos;

        // Lista de todos los casos activos en el sistema
        private List<Caso> _casos;

        /// <summary>Obtiene una copia de la lista de investigadores</summary>
        public List<Investigador> Investigadores
        {
            get { return new List<Investigador>(_investigadores); }
        }

        /// <summary>Obtiene una copia de la lista de sospechosos</summary>
        public List<Sospechoso> Sospechosos
        {
            get { return new List<Sospechoso>(_sospechosos); }
        }

        /// <summary>Obtiene una copia de la lista de casos</summary>
        public List<Caso> Casos
        {
            get { return new List<Caso>(_casos); }
        }

        /// <summary>
        /// Constructor que inicializa el sistema con listas vacías.
        /// Las listas se llenarán con datos de prueba cuando se llame a PrecargarDatos().
        /// </summary>
        public Sistema()
        {
            _investigadores = new List<Investigador>();
            _sospechosos = new List<Sospechoso>();
            _casos = new List<Caso>();
        }

        /// <summary>
        /// Carga los datos de prueba del sistema.
        /// Llama a los tres métodos de precarga:
        /// 1. PrecargarInvestigadores() - Carga 10 investigadores (5 Detectives y 5 Fiscales)
        /// 2. PrecargarSospechosos() - Carga 15 sospechosos
        /// 3. PrecargarCasos() - Carga 10 casos con evidencias
        /// </summary>
        public void PrecargarDatos()
        {
            PrecargarInvestigadores();
            PrecargarSospechosos();
            PrecargarCasos();
        }

        private void PrecargarInvestigadores()
        {
            // Precarga de 5 detectives
            AltaInvestigador(new Investigador("juan.rodriguez@fiscalia.gov.uy", "Pass2024#Jcr", "Juan Carlos Rodríguez", Rol.DETECTIVE));
            AltaInvestigador(new Investigador("maria.garcia@fiscalia.gov.uy", "Pass2024#Meg", "María Elena García", Rol.DETECTIVE));
            AltaInvestigador(new Investigador("luis.lopez@fiscalia.gov.uy", "Pass2024#Lfl", "Luis Fernando López", Rol.DETECTIVE));
            AltaInvestigador(new Investigador("ana.martinez@fiscalia.gov.uy", "Pass2024#Abm", "Ana Beatriz Martínez", Rol.DETECTIVE));
            AltaInvestigador(new Investigador("carlos.silva@fiscalia.gov.uy", "Pass2024#Cas", "Carlos Alberto Silva", Rol.DETECTIVE));

            // Precarga de 5 fiscales
            AltaInvestigador(new Investigador("roberto.diaz@fiscalia.gov.uy", "FiscalPass#2024", "Roberto Enrique Díaz", Rol.FISCAL));
            AltaInvestigador(new Investigador("patricia.flores@fiscalia.gov.uy", "FiscalPass#2024", "Patricia Marisa Flores", Rol.FISCAL));
            AltaInvestigador(new Investigador("fernando.gomez@fiscalia.gov.uy", "FiscalPass#2024", "Fernando Alejandro Gómez", Rol.FISCAL));
            AltaInvestigador(new Investigador("margarita.romero@fiscalia.gov.uy", "FiscalPass#2024", "Margarita Lucía Romero", Rol.FISCAL));
            AltaInvestigador(new Investigador("victor.pena@fiscalia.gov.uy", "FiscalPass#2024", "Víctor Manuel Peña", Rol.FISCAL));
        }

        private void PrecargarSospechosos()
        {
            // Precarga de 15 sospechosos
            AltaSospechoso(new Sospechoso("Miguel Ángel Torres", "4521836", new DateTime(1985, 3, 15), true));
            AltaSospechoso(new Sospechoso("Diego Fernando Castro", "5234891", new DateTime(1978, 7, 22), true));
            AltaSospechoso(new Sospechoso("Javier Ignacio Núñez", "6145729", new DateTime(1992, 1, 10), false));
            AltaSospechoso(new Sospechoso("Raúl Patricio Benítez", "4829561", new DateTime(1980, 5, 18), true));
            AltaSospechoso(new Sospechoso("Oscar Haroldo Vargas", "5671243", new DateTime(1988, 9, 25), false));
            AltaSospechoso(new Sospechoso("Sergio Guillermo Acosta", "4356782", new DateTime(1975, 11, 30), true));
            AltaSospechoso(new Sospechoso("Andrés Felipe Cortés", "5892341", new DateTime(1990, 4, 12), false));
            AltaSospechoso(new Sospechoso("Héctor Mauricio Dávila", "4734561", new DateTime(1982, 8, 20), true));
            AltaSospechoso(new Sospechoso("Ricardo Edmundo Espinoza", "5123469", new DateTime(1986, 2, 14), false));
            AltaSospechoso(new Sospechoso("Gonzalo Iván Fernández", "4967853", new DateTime(1979, 6, 28), true));
            AltaSospechoso(new Sospechoso("Arturo Jorge García", "5456238", new DateTime(1993, 10, 5), false));
            AltaSospechoso(new Sospechoso("Ramón Kadir Hernández", "4685291", new DateTime(1981, 12, 17), true));
            AltaSospechoso(new Sospechoso("Eduardo Lucio Ibáñez", "5734821", new DateTime(1989, 3, 22), false));
            AltaSospechoso(new Sospechoso("Rodrigo Mateo Jiménez", "4812563", new DateTime(1977, 9, 11), true));
            AltaSospechoso(new Sospechoso("Vicente Nicolás López", "5298417", new DateTime(1994, 5, 30), false));
        }

        private void PrecargarCasos()
        {
            // CASO 1: Hurto
            Investigador detective1 = BuscarInvestigadorPorEmail("juan.rodriguez@fiscalia.gov.uy");
            Sospechoso sospechoso1 = BuscarSospechosoPorCedula("4521836");
            Caso caso1 = new Caso(
                "Hurto",
                "La Fiscalía investiga la sustracción de varios dispositivos electrónicos de un comercio ubicado en Montevideo. Según la denuncia presentada por el propietario, durante la noche desaparecieron cinco teléfonos celulares y dos computadoras portátiles, sin que se observaran daños evidentes en las puertas o ventanas del establecimiento. El inventario permitió establecer el valor aproximado de los bienes faltantes. Las primeras diligencias incluyeron el análisis de las cámaras de seguridad, la inspección del local y la recepción de declaraciones de empleados y vecinos. Entre las evidencias incorporadas se encuentran una herramienta abandonada cerca de una salida secundaria, una grabación del estacionamiento y testimonios que describen movimientos sospechosos durante la madrugada. La investigación busca establecer cómo se produjo la sustracción, identificar a sus responsables y determinar si existió planificación previa.",
                sospechoso1,
                detective1);
            AltaCaso(caso1);
            caso1.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 8, 12), "Herramienta metálica encontrada cerca de una salida secundaria del comercio. Se documentó su ubicación y se remitió para análisis de posibles rastros papilares. Para esta precarga, se considera que el análisis identificó huellas compatibles con el sospechoso principal.", true));
            caso1.AgregarEvidencia(new Grabacion(new DateTime(2026, 8, 13), "Grabación de una cámara del estacionamiento que muestra a una persona acercándose a la salida secundaria y retirándose con un objeto voluminoso durante el intervalo investigado. La imagen permite observar movimientos y vestimenta, pero no identificar inequívocamente el rostro.", 3, false));
            caso1.AgregarEvidencia(new Testimonio(new DateTime(2026, 8, 14), "Declaración de un empleado que afirma haber visto al sospechoso cerca del comercio durante la tarde anterior al descubrimiento de la sustracción. El testigo no presenció directamente la desaparición de los dispositivos.", "Verónica Acosta", Credibilidad.MEDIO));
            caso1.AgregarEvidencia(new Testimonio(new DateTime(2025, 12, 3), "Declaración de un vecino que recuerda haber escuchado ruidos cerca de la salida secundaria durante la madrugada. No pudo identificar a ninguna persona y su descripción del horario es aproximada.", "Ricardo Olivera", Credibilidad.BAJO));

            // CASO 2: Rapiña
            Investigador detective2 = BuscarInvestigadorPorEmail("maria.garcia@fiscalia.gov.uy");
            Sospechoso sospechoso2 = BuscarSospechosoPorCedula("5671243");
            Caso caso2 = new Caso(
                "Rapiña",
                "Se investiga una rapiña ocurrida durante la noche en un minimercado del departamento de Canelones. De acuerdo con la denuncia, una persona ingresó al establecimiento, amenazó al empleado que atendía la caja y exigió la entrega del dinero de la recaudación. El responsable abandonó el lugar con el efectivo y algunos productos antes de la llegada de la Policía. La víctima no presentó lesiones físicas, aunque declaró haber sentido temor durante el episodio. Los investigadores recopilaron imágenes de las cámaras interiores, registros de llamadas al servicio de emergencias y declaraciones de personas que se encontraban en las inmediaciones. También se examinan posibles coincidencias con otros hechos denunciados en la zona. La investigación procura identificar al autor, reconstruir sus movimientos y determinar las circunstancias relevantes para establecer la eventual responsabilidad penal.",
                sospechoso2,
                detective2);
            AltaCaso(caso2);
            caso2.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 9, 2), "Prenda de vestir encontrada en las inmediaciones del comercio después del hecho. Se documentó su ubicación y se realizó un examen de rastros. En este escenario, el análisis no permitió identificar huellas atribuibles al sospechoso principal.", false));
            caso2.AgregarEvidencia(new Grabacion(new DateTime(2026, 9, 2), "Grabación de la cámara interior del minimercado. Registra el ingreso de una persona, el acercamiento al mostrador y la retirada del establecimiento después de que el empleado entrega dinero. La secuencia muestra el desarrollo del hecho, pero la resolución no permite confirmar la identidad del autor.", 4, true));
            caso2.AgregarEvidencia(new Testimonio(new DateTime(2026, 9, 3), "Declaración del empleado que atendía la caja. Describe las amenazas recibidas, el aspecto general del autor y la secuencia de la sustracción. Reconoce que no pudo observar con precisión todos los rasgos faciales.", "Marcelo Cabrera", Credibilidad.ALTO));
            caso2.AgregarEvidencia(new Testimonio(new DateTime(2026, 2, 10), "Declaración de una persona que se encontraba en la acera opuesta y observó a un individuo salir rápidamente del comercio. No vio el interior del local ni puede asegurar que la persona observada fuera quien cometió la rapiña.", "Natalia Ferreira", Credibilidad.MEDIO));

            // CASO 3: Estafa
            Investigador detective3 = BuscarInvestigadorPorEmail("luis.lopez@fiscalia.gov.uy");
            Sospechoso sospechoso3 = BuscarSospechosoPorCedula("5234891");
            Caso caso3 = new Caso(
                "Estafa",
                "La investigación comenzó tras varias denuncias de personas que transfirieron dinero para reservar viviendas anunciadas como alquileres temporarios. Posteriormente, los denunciantes descubrieron que las propiedades no estaban disponibles o que quienes publicaban los anuncios no tenían autorización para ofrecerlas. Los anuncios presentaban fotografías similares, condiciones de pago prácticamente idénticas y números de contacto relacionados entre sí. Entre las evidencias recopiladas figuran comprobantes de transferencias bancarias, capturas de pantalla de las publicaciones y conversaciones mantenidas con el presunto responsable. También se solicitaron informes a las entidades financieras para identificar las cuentas receptoras de los pagos. La Fiscalía busca determinar si existió una maniobra reiterada, establecer la participación individual de los involucrados, cuantificar el perjuicio económico y localizar a otras posibles víctimas de la misma actividad.",
                sospechoso3,
                detective3);
            AltaCaso(caso3);
            caso3.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 5, 20), "Teléfono celular entregado voluntariamente para una pericia autorizada dentro de la investigación. Se documentaron sus características y se preservaron los datos pertinentes mediante los procedimientos correspondientes. En este escenario, el examen no detectó huellas atribuibles al sospechoso principal en la superficie exterior del dispositivo.", false));
            caso3.AgregarEvidencia(new Grabacion(new DateTime(2026, 5, 21), "Grabación de una cámara de acceso a un edificio que registra a una persona ingresando durante el período en que se habrían realizado algunas gestiones relacionadas con los anuncios. El video aporta información temporal y de desplazamiento, pero no demuestra por sí solo la existencia de una maniobra fraudulenta ni permite confirmar la identidad del individuo.", 2, false));
            caso3.AgregarEvidencia(new Testimonio(new DateTime(2026, 5, 22), "Declaración de una persona que afirma haber transferido dinero como reserva de una vivienda anunciada en una plataforma digital. Presenta comprobantes bancarios y explica que perdió contacto con quien ofrecía el alquiler después de realizar el pago.", "Gabriela Núñez", Credibilidad.ALTO));
            caso3.AgregarEvidencia(new Testimonio(new DateTime(2025, 11, 18), "Declaración de otro denunciante que describe una operación similar realizada meses antes. Conserva capturas de pantalla de la publicación y recuerda el importe transferido, aunque no dispone de toda la conversación original.", "Esteban Sosa", Credibilidad.MEDIO));

            // CASO 4: Lesiones personales
            Investigador detective4 = BuscarInvestigadorPorEmail("ana.martinez@fiscalia.gov.uy");
            Sospechoso sospechoso4 = BuscarSospechosoPorCedula("6145729");
            Caso caso4 = new Caso(
                "Lesiones personales",
                "La Fiscalía investiga una agresión ocurrida a la salida de un local nocturno de Maldonado. Según las primeras declaraciones, una discusión entre varias personas derivó en una confrontación física durante la cual un individuo recibió golpes que le provocaron lesiones en el rostro y en uno de sus brazos. La víctima fue trasladada a un centro asistencial, donde recibió atención médica. El informe correspondiente documenta las lesiones y permite evaluar su entidad. Los investigadores obtuvieron fotografías del lugar, solicitaron grabaciones de establecimientos cercanos y recibieron declaraciones de personas que presenciaron parte del altercado. Algunos testigos sostienen que la discusión comenzó dentro del local, mientras que otros solamente observaron el enfrentamiento en la vía pública. La investigación pretende reconstruir la secuencia de los acontecimientos, establecer la participación de cada involucrado y determinar la calificación jurídica que corresponda.",
                sospechoso4,
                detective4);
            AltaCaso(caso4);
            caso4.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 7, 7), "Camisa utilizada por la víctima durante el altercado, entregada para documentar manchas y posibles rastros relacionados con el contacto físico. Se registró su estado al recibirla y se conservó para las pericias pertinentes. En este escenario, el examen no identificó huellas atribuibles al sospechoso principal.", false));
            caso4.AgregarEvidencia(new Grabacion(new DateTime(2026, 7, 8), "Video de una cámara instalada en la entrada del local. Registra una discusión entre varias personas y parte del enfrentamiento posterior en la vía pública. Las imágenes permiten observar movimientos y posiciones relativas, pero no muestran con claridad quién inició la agresión ni permiten identificar inequívocamente a todos los participantes.", 3, false));
            caso4.AgregarEvidencia(new Testimonio(new DateTime(2026, 7, 9), "Declaración de una persona que presenció parte del altercado desde la entrada del establecimiento. Afirma haber visto al sospechoso acercarse a la víctima durante la discusión, aunque no puede precisar todos los movimientos posteriores.", "Patricia Méndez", Credibilidad.MEDIO));
            caso4.AgregarEvidencia(new Testimonio(new DateTime(2025, 9, 15), "Declaración de un trabajador del local que recuerda una discusión previa entre los involucrados. No presenció directamente las lesiones, pero aporta información sobre el conflicto que pudo preceder al enfrentamiento.", "Álvaro Correa", Credibilidad.BAJO));

            // CASO 5: Homicidio
            Investigador detective5 = BuscarInvestigadorPorEmail("carlos.silva@fiscalia.gov.uy");
            Sospechoso sospechoso5 = BuscarSospechosoPorCedula("4356782");
            Caso caso5 = new Caso(
                "Homicidio",
                "La Policía encontró a una persona adulta fallecida en una vivienda de Montevideo después de recibir un aviso de emergencia realizado por un vecino. La escena fue preservada para permitir el trabajo de Policía Científica y del personal médico forense. Las primeras actuaciones documentaron la posición del cuerpo, el estado de las habitaciones y diversos objetos presentes en el inmueble. Un vecino declaró haber escuchado una discusión durante la noche anterior, mientras que otra persona informó haber observado movimientos inusuales en las inmediaciones. La investigación incorporó fotografías de la escena, informes médico-forenses preliminares y registros de cámaras instaladas en la zona. También se dispuso el análisis de muestras recogidas durante la inspección. La Fiscalía procura establecer la causa y las circunstancias de la muerte, reconstruir los acontecimientos e identificar a quienes pudieran haber participado en el hecho.",
                sospechoso5,
                detective5);
            AltaCaso(caso5);
            caso5.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 3, 12), "Objeto metálico recogido en una habitación de la vivienda y documentado durante la inspección. Se embaló para preservar posibles rastros y se remitió a análisis. En este escenario ficticio, la pericia identificó huellas compatibles con el sospechoso principal, aunque la interpretación del hallazgo requiere considerar el contexto y los demás elementos de la investigación.", true));
            caso5.AgregarEvidencia(new Grabacion(new DateTime(2026, 3, 13), "Registro de una cámara instalada frente a la vivienda. Las imágenes muestran a una persona ingresando al inmueble durante el período relevante y retirándose más tarde. La grabación permite establecer una secuencia temporal, pero no registra el interior de la vivienda ni demuestra directamente las circunstancias de la muerte.", 4, false));
            caso5.AgregarEvidencia(new Testimonio(new DateTime(2026, 3, 14), "Declaración de un vecino que afirma haber escuchado una discusión durante la noche anterior al hallazgo del cuerpo. Describe sonidos y horarios aproximados, pero no pudo observar directamente a las personas que participaban en el intercambio.", "Susana Pereira", Credibilidad.ALTO));
            caso5.AgregarEvidencia(new Testimonio(new DateTime(2025, 8, 21), "Declaración de una persona conocida de la víctima que describe circunstancias previas relevantes para reconstruir sus últimos contactos. No presenció el hecho investigado y parte de su información procede de conversaciones mantenidas con terceros.", "Daniel Vázquez", Credibilidad.MEDIO));

            // CASO 6: Abuso sexual
            Investigador detective6 = BuscarInvestigadorPorEmail("juan.rodriguez@fiscalia.gov.uy");
            Sospechoso sospechoso6 = BuscarSospechosoPorCedula("5892341");
            Caso caso6 = new Caso(
                "Abuso sexual",
                "La Fiscalía investiga una denuncia por un presunto delito sexual ocurrido durante una reunión privada en el departamento de Canelones. La persona denunciante manifestó que conocía previamente al denunciado y que, durante el encuentro, se produjo un contacto sexual que no había consentido. La denuncia fue recibida procurando preservar la intimidad y la dignidad de la persona afectada. Las actuaciones iniciales incluyeron la recepción de su declaración, la identificación de posibles testigos y la solicitud de comunicaciones que pudieran contribuir al esclarecimiento de los hechos. También se evaluó la pertinencia de realizar pericias y otras diligencias legalmente procedentes. La investigación debe establecer las circunstancias del encuentro, analizar los elementos disponibles y determinar si se configuran los elementos del tipo penal correspondiente. La calificación jurídica definitiva dependerá de los hechos que logren acreditarse y de la legislación aplicable.",
                sospechoso6,
                detective6);
            AltaCaso(caso6);
            caso6.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 4, 25), "Prenda de vestir aportada voluntariamente por la persona denunciante y recibida conforme al procedimiento de documentación de evidencias. Se registró su procedencia y estado de conservación para determinar si correspondían análisis periciales. En este escenario, el examen no identificó huellas atribuibles al sospechoso principal. La ausencia de ese hallazgo no determina por sí misma la existencia o inexistencia del hecho denunciado.", false));
            caso6.AgregarEvidencia(new Grabacion(new DateTime(2026, 4, 26), "Registro de una cámara instalada en el acceso al edificio donde habría ocurrido el encuentro. La grabación permite observar el ingreso y la salida de personas durante el período relevante, pero no muestra el interior del inmueble ni permite establecer por sí sola si existió consentimiento. Su utilidad consiste principalmente en ayudar a reconstruir los horarios y la presencia de las personas involucradas.", 2, false));
            caso6.AgregarEvidencia(new Testimonio(new DateTime(2026, 4, 27), "Declaración de una persona de confianza de la denunciante que describe una conversación mantenida poco después del episodio denunciado. El testigo relata lo que le fue comunicado, sin afirmar haber presenciado directamente los hechos investigados.", "Mariana Olivera", Credibilidad.ALTO));
            caso6.AgregarEvidencia(new Testimonio(new DateTime(2025, 12, 12), "Declaración de una persona que participó en la reunión y puede aportar información sobre la presencia de los involucrados y las circunstancias generales del encuentro. No estuvo presente durante todo el período relevante y no observó directamente el hecho denunciado.", "Sergio Domínguez", Credibilidad.MEDIO));

            // CASO 7: Abuso sexual especialmente agravado
            Investigador detective7 = BuscarInvestigadorPorEmail("maria.garcia@fiscalia.gov.uy");
            Sospechoso sospechoso7 = BuscarSospechosoPorCedula("5123469");
            Caso caso7 = new Caso(
                "Abuso sexual especialmente agravado",
                "La Fiscalía recibió una denuncia por presuntos actos de naturaleza sexual contra una persona menor de edad, atribuidos a un adulto de su entorno cercano. La situación llegó a conocimiento de las autoridades después de que una persona responsable de su cuidado comunicara información que generó preocupación. Las actuaciones se desarrollan con especial atención al interés superior de la persona menor de edad, procurando evitar interrogatorios innecesarios y situaciones que puedan ocasionarle nuevos daños. Entre las diligencias previstas se encuentran la intervención de profesionales especializados, la recepción de testimonios pertinentes y el análisis de comunicaciones que pudieran resultar relevantes. También se examinan las circunstancias de la relación entre las personas involucradas y la posible existencia de una situación de confianza o dependencia. La investigación procura esclarecer los hechos, evaluar las evidencias disponibles y determinar la calificación jurídica que corresponda conforme a la legislación uruguaya.",
                sospechoso7,
                detective7);
            AltaCaso(caso7);
            caso7.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 6, 3), "Dispositivo electrónico aportado durante la investigación para el análisis autorizado de comunicaciones pertinentes. Se documentaron sus características y se registró su recepción. En este escenario ficticio, no se encontraron huellas atribuibles al sospechoso principal en la superficie exterior del dispositivo. Los datos digitales eventualmente relevantes deben valorarse de acuerdo con su autenticidad, integridad y contexto.", false));
            caso7.AgregarEvidencia(new Grabacion(new DateTime(2026, 6, 4), "Grabación de una cámara situada en un acceso exterior que registra movimientos de personas durante el período investigado. El material permite establecer horarios aproximados y presencia en las inmediaciones, pero no registra el interior del inmueble ni muestra el presunto acto denunciado. Se preserva para contrastar la cronología con otras evidencias.", 3, false));
            caso7.AgregarEvidencia(new Testimonio(new DateTime(2026, 6, 5), "Declaración de una persona responsable del cuidado de la persona menor de edad, quien explica las circunstancias en que tomó conocimiento de la denuncia. Su relato incluye observaciones personales y las medidas adoptadas para solicitar asistencia a las autoridades. La declaración no sustituye la investigación de los hechos denunciados.", "Claudia Ferreira", Credibilidad.ALTO));
            caso7.AgregarEvidencia(new Testimonio(new DateTime(2025, 10, 30), "Declaración de un adulto que conoce el entorno familiar y puede aportar información contextual sobre los vínculos entre las personas involucradas. No presenció directamente los hechos denunciados y distingue entre sus propias observaciones y la información que recibió de otras personas.", "Roberto Acosta", Credibilidad.BAJO));

            // CASO 8: Negociación de sustancias estupefacientes
            Investigador detective8 = BuscarInvestigadorPorEmail("luis.lopez@fiscalia.gov.uy");
            Sospechoso sospechoso8 = BuscarSospechosoPorCedula("4967853");
            Caso caso8 = new Caso(
                "Negociación de sustancias estupefacientes",
                "La investigación se inició a partir de información sobre una presunta actividad de comercialización de sustancias estupefacientes en una vivienda del área metropolitana. Durante las actuaciones policiales se incautaron sustancias cuya composición y peso deben establecerse mediante pericias químicas, además de dinero en efectivo, teléfonos celulares y anotaciones que podrían guardar relación con la actividad investigada. Los elementos fueron documentados y sometidos a procedimientos destinados a preservar su integridad y trazabilidad. La Fiscalía procura determinar la naturaleza de las sustancias, establecer su procedencia y analizar si las evidencias permiten vincular a las personas investigadas con actividades de distribución o comercialización. También se examinan las comunicaciones obtenidas legalmente y las declaraciones de posibles testigos. La eventual tipificación y las responsabilidades individuales dependerán del resultado de las pericias y del conjunto de evidencias reunidas.",
                sospechoso8,
                detective8);
            AltaCaso(caso8);
            caso8.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 9, 18), "Paquete con una sustancia sospechosa incautado durante un procedimiento policial y remitido para análisis químico. Se registraron el lugar del hallazgo, las condiciones de embalaje y la transferencia al laboratorio correspondiente. En este escenario, el análisis de rastros identificó huellas compatibles con el sospechoso principal. La naturaleza de la sustancia y el significado de su presencia deben establecerse mediante las pericias y el resto de la evidencia.", true));
            caso8.AgregarEvidencia(new Grabacion(new DateTime(2026, 9, 19), "Grabación de una cámara que registra un intercambio de objetos entre dos personas en las inmediaciones del lugar investigado. La secuencia permite observar la aproximación, el contacto y la separación de los individuos. Sin embargo, el contenido de los objetos no resulta visible y la grabación no demuestra por sí sola que se haya producido una transacción de sustancias estupefacientes.", 4, true));
            caso8.AgregarEvidencia(new Testimonio(new DateTime(2026, 9, 20), "Declaración de una persona que afirma haber observado intercambios frecuentes entre distintos individuos en las inmediaciones del inmueble. Describe los horarios y los movimientos que recuerda, aunque reconoce que no pudo identificar el contenido de los objetos intercambiados.", "Eduardo Sosa", Credibilidad.ALTO));
            caso8.AgregarEvidencia(new Testimonio(new DateTime(2025, 7, 14), "Declaración de un vecino que describe una actividad inusual en la vivienda durante meses anteriores. El testigo aporta información sobre horarios y visitas, pero no presenció directamente ninguna operación de compraventa ni puede determinar la naturaleza de los objetos observados.", "Beatriz Núñez", Credibilidad.MEDIO));

            // CASO 9: Falsificación ideológica por un particular en documento público
            Investigador detective9 = BuscarInvestigadorPorEmail("ana.martinez@fiscalia.gov.uy");
            Sospechoso sospechoso9 = BuscarSospechosoPorCedula("5456238");
            Caso caso9 = new Caso(
                "Falsificación ideológica por un particular en documento público",
                "La Fiscalía investiga la presunta presentación de documentación pública con información falsa ante una oficina administrativa para obtener un beneficio económico. Durante un procedimiento de verificación, los funcionarios detectaron discrepancias entre los datos consignados en los documentos presentados y los registros oficiales consultados. La documentación cuestionada contiene información relativa a la identidad y a determinadas circunstancias personales de quien la presentó. Entre las evidencias incorporadas figuran copias autenticadas de los documentos, informes administrativos y declaraciones de los funcionarios que participaron en su recepción y control. También se solicitó información a las dependencias responsables de los registros originales para determinar el origen de las discrepancias. La investigación busca establecer quién elaboró o presentó la documentación, si existió intención de engañar a la Administración y qué consecuencias jurídicas corresponden según la naturaleza del documento y los hechos acreditados.",
                sospechoso9,
                detective9);
            AltaCaso(caso9);
            caso9.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 2, 17), "Documento presentado ante una oficina administrativa y posteriormente cuestionado por discrepancias con los registros oficiales. Se obtuvo una copia autenticada y se documentó su relación con el trámite investigado. En este escenario, el análisis de la superficie del documento no identificó huellas atribuibles al sospechoso principal. La investigación deberá determinar si la información es falsa, cómo se incorporó y qué participación tuvo cada persona involucrada.", false));
            caso9.AgregarEvidencia(new Grabacion(new DateTime(2026, 2, 18), "Grabación del sistema de videovigilancia de la oficina administrativa que registra la atención de una persona durante el trámite cuestionado. Las imágenes muestran la presentación de documentación y la interacción con un funcionario, aunque no permiten leer el contenido de los documentos ni determinar su autenticidad. El material se utiliza para contrastar la cronología de las actuaciones.", 3, false));
            caso9.AgregarEvidencia(new Testimonio(new DateTime(2026, 2, 19), "Declaración del funcionario que recibió la documentación. Explica el procedimiento administrativo seguido y describe las discrepancias detectadas durante la verificación posterior. No afirma conocer quién elaboró originalmente el documento cuestionado.", "Leticia Cabrera", Credibilidad.ALTO));
            caso9.AgregarEvidencia(new Testimonio(new DateTime(2025, 8, 9), "Declaración de una persona que participó en un trámite relacionado y puede aportar información sobre la documentación presentada y las gestiones realizadas. Su conocimiento es parcial y no permite establecer por sí solo quién introdujo los datos cuestionados.", "Mario Techera", Credibilidad.MEDIO));

            // CASO 10: Daño
            Investigador detective10 = BuscarInvestigadorPorEmail("carlos.silva@fiscalia.gov.uy");
            Sospechoso sospechoso10 = BuscarSospechosoPorCedula("4685291");
            Caso caso10 = new Caso(
                "Daño",
                "La Fiscalía investiga daños ocasionados durante un fin de semana en las instalaciones de un centro educativo público de Montevideo. Al llegar al establecimiento, el personal responsable encontró varias ventanas rotas, mobiliario deteriorado y pintadas en paredes interiores y exteriores. La dirección presentó una denuncia acompañada de un inventario de los bienes afectados y una estimación inicial de los costos de reparación. Las primeras actuaciones incluyeron fotografías de los daños, inspección del lugar y entrevistas a funcionarios encargados del mantenimiento. También se solicitaron grabaciones de cámaras de seguridad de inmuebles cercanos para determinar si registraron movimientos relevantes durante el período investigado. La Fiscalía procura establecer si los daños se produjeron en un único episodio o en varios, identificar a sus posibles autores y cuantificar el perjuicio patrimonial ocasionado al establecimiento.",
                sospechoso10,
                detective10);
            AltaCaso(caso10);
            caso10.AgregarEvidencia(new EvidenciaFisica(new DateTime(2026, 10, 2), "Fragmentos de vidrio recogidos junto a una ventana rota del centro educativo. Se fotografiaron antes de su recolección y se registraron el lugar exacto y las condiciones en que fueron encontrados. En este escenario, el análisis identificó huellas compatibles con el sospechoso principal en uno de los fragmentos conservados. El hallazgo debe interpretarse junto con la ubicación de la muestra y las demás circunstancias documentadas.", true));
            caso10.AgregarEvidencia(new Grabacion(new DateTime(2026, 10, 3), "Grabación de una cámara exterior que muestra a una persona aproximándose al centro educativo y realizando movimientos cerca de una ventana durante el período investigado. La secuencia permite observar la actividad y el posterior alejamiento, aunque no registra con claridad todos los detalles del daño. Para este escenario, las imágenes permiten reconocer al sospechoso y documentar su presencia durante la ejecución del hecho.", 5, true));
            caso10.AgregarEvidencia(new Testimonio(new DateTime(2026, 10, 4), "Declaración de un funcionario del centro educativo que encontró los daños al llegar por la mañana. Describe el estado de las instalaciones y aporta información sobre los últimos controles efectuados antes del cierre. No presenció directamente la rotura de las ventanas.", "Mónica Pereira", Credibilidad.ALTO));
            caso10.AgregarEvidencia(new Testimonio(new DateTime(2026, 1, 11), "Declaración de un residente cercano que recuerda haber escuchado ruidos en las inmediaciones del establecimiento durante un fin de semana anterior. No pudo identificar a las personas involucradas y no está seguro de que los sonidos correspondieran al episodio investigado.", "Gustavo Silva", Credibilidad.BAJO));
        }



        /// <summary>
        /// Registra un nuevo investigador en el sistema.
        /// Valida sus datos y comprueba que el email sea único.
        /// </summary>
        /// <param name="investigador">Investigador a registrar (Detective o Fiscal)</param>
        /// <exception cref="Exception">Si el investigador es nulo, sus datos no son válidos, o el email ya existe</exception>
        public void AltaInvestigador(Investigador investigador)
        {
            if (investigador == null)
            {
                throw new Exception("El investigador no puede ser nulo");
            }

            investigador.Validar();

            // Verificar que el email sea único
            foreach (Investigador inv in _investigadores)
            {
                if (inv.Email == investigador.Email)
                {
                    throw new Exception("El email ya existe en el sistema");
                }
            }

            _investigadores.Add(investigador);
        }

        /// <summary>
        /// Registra un nuevo sospechoso en el sistema.
        /// Valida sus datos y comprueba que la cédula sea única.
        /// </summary>
        /// <param name="sospechoso">Sospechoso a registrar</param>
        /// <exception cref="Exception">Si el sospechoso es nulo, sus datos no son válidos, o la cédula ya existe</exception>
        public void AltaSospechoso(Sospechoso sospechoso)
        {
            if (sospechoso == null)
            {
                throw new Exception("El sospechoso no puede ser nulo");
            }

            sospechoso.Validar();

            // Verificar que la cédula sea única
            foreach (Sospechoso sosp in _sospechosos)
            {
                if (sosp.Cedula == sospechoso.Cedula)
                {
                    throw new Exception("La cédula ya existe en el sistema");
                }
            }

            _sospechosos.Add(sospechoso);
        }

        /// <summary>
        /// Registra un nuevo caso en el sistema.
        /// Valida sus datos y comprueba que el detective esté registrado en el sistema.
        /// </summary>
        /// <param name="caso">Caso a registrar</param>
        /// <exception cref="Exception">Si el caso es nulo, sus datos no son válidos, o el detective no está registrado</exception>
        public void AltaCaso(Caso caso)
        {
            if (caso == null)
            {
                throw new Exception("El caso no puede ser nulo");
            }

            caso.Validar();

            // Verificar que el detective esté registrado en el sistema
            bool detectiveEncontrado = false;
            foreach (Investigador investigador in _investigadores)
            {
                if (caso.TieneAsignadoDetective(investigador))
                {
                    detectiveEncontrado = true;
                    break;
                }
            }

            if (!detectiveEncontrado)
            {
                throw new Exception("El detective asignado no está registrado en el sistema");
            }

            _casos.Add(caso);
        }

        /// <summary>
        /// Obtiene una copia de la lista de todos los casos del sistema.
        /// </summary>
        /// <returns>Lista completa de casos</returns>
        public List<Caso> ObtenerCasos()
        {
            return new List<Caso>(_casos);
        }

        /// <summary>
        /// Busca un caso específico por su ID único.
        /// </summary>
        /// <param name="id">ID del caso a buscar</param>
        /// <returns>El caso encontrado, o null si no existe</returns>
        public Caso BuscarCasosPorId(int id)
        {
            foreach (Caso caso in _casos)
            {
                if (caso.Id == id)
                {
                    return caso;
                }
            }

            return null;
        }

        /// <summary>
        /// Obtiene todos los casos asignados a un detective específico.
        /// </summary>
        /// <param name="email">Email del investigador/detective</param>
        /// <returns>Lista de casos asignados a ese investigador</returns>
        public List<Caso> ObtenerCasosPorInvestigador(string email)
        {
            List<Caso> casosPorInvestigador = new List<Caso>();

            // Buscar al investigador por email
            Investigador investigador = BuscarInvestigadorPorEmail(email);
            if (investigador == null)
            {
                return casosPorInvestigador;
            }

            // Buscar casos asignados a ese investigador
            foreach (Caso caso in _casos)
            {
                if (caso.TieneAsignadoDetective(investigador))
                {
                    casosPorInvestigador.Add(caso);
                }
            }

            return casosPorInvestigador;
        }

        /// <summary>
        /// Obtiene todos los sospechosos que tienen antecedentes penales registrados.
        /// Los sospechosos con antecedentes tienen un peso adicional en la evaluación de casos.
        /// </summary>
        /// <returns>Lista de sospechosos con antecedentes penales</returns>
        public List<Sospechoso> ObtenerSospechososConAntecedentes()
        {
            List<Sospechoso> sospechososConAntecedentes = new List<Sospechoso>();

            foreach (Sospechoso sospechoso in _sospechosos)
            {
                if (sospechoso.TieneAntecedentes)
                {
                    sospechososConAntecedentes.Add(sospechoso);
                }
            }

            return sospechososConAntecedentes;
        }

        /// <summary>
        /// Busca un investigador específico por su email único.
        /// </summary>
        /// <param name="email">Email del investigador a buscar</param>
        /// <returns>El investigador encontrado, o null si no existe</returns>
        public Investigador BuscarInvestigadorPorEmail(string email)
        {
            foreach (Investigador investigador in _investigadores)
            {
                if (investigador.Email == email)
                {
                    return investigador;
                }
            }

            return null;
        }

        /// <summary>
        /// Busca un sospechoso específico por su número de cédula única.
        /// </summary>
        /// <param name="cedula">Cédula del sospechoso a buscar</param>
        /// <returns>El sospechoso encontrado, o null si no existe</returns>
        public Sospechoso BuscarSospechosoPorCedula(string cedula)
        {
            foreach (Sospechoso sospechoso in _sospechosos)
            {
                if (sospechoso.Cedula == cedula)
                {
                    return sospechoso;
                }
            }

            return null;
        }
    }
}
