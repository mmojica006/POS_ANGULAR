namespace POS.Infrastructure.Commons.Bases.Response
{
    /// <summary>
    /// Devuelve los registros de la BD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}
