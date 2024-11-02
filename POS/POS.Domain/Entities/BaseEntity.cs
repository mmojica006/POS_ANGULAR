namespace POS.Domain.Entities
{
    /// <summary>
    /// Nos va a ayudar a hacer de una forma genérica nuestras entidades para poder aplciar los métodos CRUD
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }
        public int State { get; set; }

    }
}
