namespace ObligatorioP2
{
   
    internal class Program
    {

        private static Sistema sistema;

        
        static void Main(string[] args)
        {
            // Crear una nueva instancia del sistema
            sistema = new Sistema();

            // Cargar los datos de prueba (investigadores, sospechosos y casos)
            sistema.PrecargarDatos();

            // Mostrar el menú principal al usuario
            MostrarMenuPrincipal();
        }

    
        static void MostrarMenuPrincipal()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════╗");
                Console.WriteLine("║   SISTEMA DE GESTIÓN DE CASOS DE FISCALÍA         ║");
                Console.WriteLine("╚════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine();
                Console.WriteLine("  1. Listar todos los casos con sus evidencias");
                Console.WriteLine("  2. Buscar casos por email del investigador");
                Console.WriteLine("  3. Dar de alta a un nuevo sospechoso");
                Console.WriteLine("  4. Listar sospechosos con antecedentes");
                Console.WriteLine("  5. Salir");
                Console.WriteLine();
                Console.Write("Ingrese su opción (1-5): ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarCasosConEvidencias();
                        break;
                    case "2":
                        BuscarCasosPorInvestigador();
                        break;
                    case "3":
                        AltaNuevoSospechoso();
                        break;
                    case "4":
                        ListarSospechososConAntecedentes();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            }
        }

        /// <summary>
        /// Opción 1: Muestra todos los casos del sistema con sus evidencias.
        /// Muestra para cada caso: ID, nombre, sospechoso, investigador asignado, 
        /// peso de evidencias y lista detallada de evidencias.
        /// </summary>
        static void ListarCasosConEvidencias()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║              LISTADO DE CASOS                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Obtener todos los casos del sistema
            List<Caso> casos = sistema.ObtenerCasos();

            if (casos.Count == 0)
            {
                Console.WriteLine("No hay casos registrados en el sistema.");
            }
            else
            {
                // Iterar sobre cada caso y mostrar sus detalles
                foreach (Caso caso in casos)
                {
                    Console.WriteLine($"ID: {caso.Id}  |  NOMBRE: {caso.Nombre}");
                    Console.WriteLine($"   Sospechoso: {caso.ObtenerNombreSospechosoPrincipal()}  |  Investigador: {caso.ObtenerNombreDetective()}");

                    // El peso es fundamental: determina si se desestima, continúa o se imputa
                    Console.WriteLine($"   Peso de Evidencias: {caso.CalcularPesoEvidencias()}/100");
                    Console.WriteLine("   Evidencias:");

                    // Mostrar cada evidencia del caso
                    foreach (Evidencia evidencia in caso.Evidencias)
                    {
                        Console.WriteLine($"      - ID: {evidencia.Id} | {evidencia.Descripcion}");
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Presione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        /// <summary>
        /// Opción 2: Busca casos por el email del investigador asignado.
        /// Permite buscar qué casos tiene un detective específico.
        /// </summary>
        static void BuscarCasosPorInvestigador()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║        BUSCAR CASOS POR INVESTIGADOR               ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Solicitar el email del investigador
            Console.Write("Ingrese el email del investigador: ");
            string email = Console.ReadLine();

            // Buscar el investigador por email
            Investigador investigador = sistema.BuscarInvestigadorPorEmail(email);

            if (investigador == null)
            {
                Console.WriteLine("Error: No se encontró investigador con ese email.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Investigador: {investigador.Nombre} ({investigador.Rol})");
                Console.WriteLine();

                // Obtener los casos asignados a ese investigador
                List<Caso> casosPorInvestigador = sistema.ObtenerCasosPorInvestigador(email);

                if (casosPorInvestigador.Count == 0)
                {
                    Console.WriteLine("Este investigador no tiene casos asignados.");
                }
                else
                {
                    Console.WriteLine($"Casos asignados ({casosPorInvestigador.Count}):");
                    Console.WriteLine();

                    // Mostrar todos los casos del investigador
                    foreach (Caso caso in casosPorInvestigador)
                    {
                        Console.WriteLine($"  ID: {caso.Id}  |  NOMBRE: {caso.Nombre}  |  Detective: {caso.ObtenerNombreDetective()}");
                    }
                }
            }

            Console.WriteLine("Presione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        /// <summary>
        /// Opción 3: Permite registrar un nuevo sospechoso en el sistema.
        /// Solicita nombre, cédula, fecha de nacimiento y antecedentes.
        /// Valida que los datos sean correctos antes de guardar.
        /// </summary>
        static void AltaNuevoSospechoso()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║            ALTA DE NUEVO SOSPECHOSO                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine();

            try
            {
                // Solicitar datos del sospechoso
                Console.Write("Ingrese el nombre del sospechoso: ");
                string nombre = Console.ReadLine();

                if (string.IsNullOrEmpty(nombre))
                {
                    throw new Exception("El nombre no puede estar vacío");
                }

                Console.Write("Ingrese la cédula: ");
                string cedula = Console.ReadLine();

                if (string.IsNullOrEmpty(cedula))
                {
                    throw new Exception("La cédula no puede estar vacía");
                }

                Console.Write("Ingrese el año de nacimiento: ");
                string anioStr = Console.ReadLine();

                if (string.IsNullOrEmpty(anioStr))
                {
                    throw new Exception("El año no puede estar vacío");
                }

                int anio = int.Parse(anioStr);

                Console.Write("Ingrese el mes de nacimiento: ");
                string mesStr = Console.ReadLine();

                if (string.IsNullOrEmpty(mesStr))
                {
                    throw new Exception("El mes no puede estar vacío");
                }

                int mes = int.Parse(mesStr);

                Console.Write("Ingrese el día de nacimiento: ");
                string diaStr = Console.ReadLine();

                if (string.IsNullOrEmpty(diaStr))
                {
                    throw new Exception("El día no puede estar vacío");
                }

                int dia = int.Parse(diaStr);

                // Crear la fecha de nacimiento
                DateTime fechaNacimiento = new DateTime(anio, mes, dia);

                // Solicitar si tiene antecedentes (con validación)
                bool tieneAntecedentes = false;
                bool respuestaValida = false;

                while (!respuestaValida)
                {
                    Console.Write("¿Tiene antecedentes? (s/si/n/no): ");
                    string tieneAntecedentesStr = Console.ReadLine();

                    if (string.IsNullOrEmpty(tieneAntecedentesStr))
                    {
                        Console.WriteLine("La respuesta no puede estar vacía");
                        continue;
                    }

                    tieneAntecedentesStr = tieneAntecedentesStr.ToLower();

                    if (tieneAntecedentesStr == "s" || tieneAntecedentesStr == "si")
                    {
                        tieneAntecedentes = true;
                        respuestaValida = true;
                    }
                    else if (tieneAntecedentesStr == "n" || tieneAntecedentesStr == "no")
                    {
                        tieneAntecedentes = false;
                        respuestaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Respuesta inválida. Ingrese s, si, n o no.");
                    }
                }

                // Crear y registrar el nuevo sospechoso
                Sospechoso nuevoSospechoso = new Sospechoso(nombre, cedula, fechaNacimiento, tieneAntecedentes);
                sistema.AltaSospechoso(nuevoSospechoso);

                Console.WriteLine("✓ Sospechoso registrado exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("✗ Error: Ingrese valores numéricos válidos para la fecha.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("✗ Error: Fecha inválida. Verifique los valores de año, mes y día.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        /// <summary>
        /// Opción 4: Muestra todos los sospechosos que tienen antecedentes penales.
        /// Los sospechosos con antecedentes aportan +10 puntos adicionales al peso del caso.
        /// </summary>
        static void ListarSospechososConAntecedentes()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║     SOSPECHOSOS CON ANTECEDENTES PENALES            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Obtener todos los sospechosos con antecedentes
            List<Sospechoso> sospechososConAntecedentes = sistema.ObtenerSospechososConAntecedentes();

            if (sospechososConAntecedentes.Count == 0)
            {
                Console.WriteLine("No hay sospechosos con antecedentes.");
            }
            else
            {
                Console.WriteLine($"Total de sospechosos con antecedentes: {sospechososConAntecedentes.Count}");
                Console.WriteLine();

                // Mostrar detalles de cada sospechoso con antecedentes
                foreach (Sospechoso sospechoso in sospechososConAntecedentes)
                {
                    Console.WriteLine($"Nombre: {sospechoso.Nombre}");
                    Console.WriteLine($"Cédula: {sospechoso.Cedula}");
                    Console.WriteLine($"Fecha de Nacimiento: {sospechoso.FechaNacimiento.ToString("dd/MM/yyyy")}");
                    Console.WriteLine("Antecedentes: Sí");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Presione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}
