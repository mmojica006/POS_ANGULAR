using POS.Domain.Entities;

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

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
