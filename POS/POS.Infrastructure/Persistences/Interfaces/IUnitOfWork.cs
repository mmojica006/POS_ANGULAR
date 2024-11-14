using POS.Domain.Entities;
using System.Data;

namespace POS.Infrastructure.Persistences.Interfaces
{
    /// <summary>
    /// Este patrón nos permite manejar transacciones durante la manipulación de datos
    /// y es importante que se pueda liberar objetos en memoria
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Declaración de interfaces a nivel de repositorio
        /// </summary>
        /// 

        IGenericRepository<Category> Category { get; }
        IGenericRepository<Provider> Provider { get; }
        IGenericRepository<DocumentType> DocumentType { get; }
       

        //ICategoryRepository Category { get; }
        //IProviderRepository Provider { get; }
        //IDocumentTypeRepository DocumentType { get; }
        IUserRepository User { get; }
        IWarehouseRepository Warehouse { get; }
        IGenericRepository<Product> Product { get; }
        IProductStockRepository ProductStock { get; }

        void SaveChanges();
        Task SaveChangesAsync();

        /// <summary>
        /// Conjunto de operaciones de base de datos que se ejecutan como una unidad atómica
        /// </summary>
        /// <returns></returns>
        IDbTransaction BeginTransaction();
    }
}
