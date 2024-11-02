namespace POS.Infrastructure.Commons.Bases.Request
{
    public class BaseFilterRequest : BasePaginationRequest
    {
        /// <summary>
        /// Que filtro voy a procesar
        /// </summary>
        public int? NumFilter { get; set; } = null;
        /// <summary>
        /// El texto a enviar para filtrar
        /// </summary>
        public string? TextFilter { get; set; } = null;
        /// <summary>
        /// El estado si inactivo o inactivo
        /// </summary>
        public int? StateFilter { get; set; } = null;

        public string? StartDate { get; set; } = null;
        public string? EndDate { get; set; } = null;
        /// <summary>
        /// Utilizado para la descarga de excel si queremos descargar todos los datos sin ninguna paginación
        /// </summary>
        public bool Download { get; set; } = false;
    }
}
