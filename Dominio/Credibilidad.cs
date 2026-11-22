namespace ObligatorioP2
{
    /// <summary>
    /// Enumeración que define los niveles de credibilidad de los testigos.
    /// La credibilidad influye en el peso que se asigna a los testimonios en la evaluación del caso.
    /// </summary>
    public enum Credibilidad
    {
        // Credibilidad baja: testigo con poca confiabilidad (valor: 1)
        BAJO = 1,

        // Credibilidad media: testigo con confiabilidad moderada (valor: 2)
        MEDIO = 2,

        // Credibilidad alta: testigo muy confiable (valor: 3)
        ALTO = 3
    }
}
