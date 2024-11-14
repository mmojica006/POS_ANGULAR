namespace POS.Domain.Entities
{
    /// <summary>
    /// Tabla compuesta y se debe de modificar con el fluentApi
    /// </summary>
    public class ProductStock
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int CurrentStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public Product Product { get; set; } = null!;
        public Warehouse Warehouse { get; set; } = null!;
    }
}
