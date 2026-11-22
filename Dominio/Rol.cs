namespace ObligatorioP2
{
    /// <summary>
    /// Enumeración que define los roles de los investigadores en el sistema.
    /// Los investigadores pueden ser DETECTIVES (encargados de la investigación) o FISCALES (encargados de decisiones legales).
    /// </summary>
    public enum Rol
    {
        // Investigador de campo responsable de recopilar evidencias e investigar casos
        DETECTIVE = 1,

        // Fiscal responsable de tomar decisiones sobre los casos investigados
        FISCAL = 2
    }
}
