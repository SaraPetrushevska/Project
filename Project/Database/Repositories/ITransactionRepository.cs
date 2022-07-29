using Project.Database.Entities;
using Project.Models;

namespace Project.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);

        Task<TransactionEntity> Create(TransactionEntity transaction);

        Task<TransactionEntity> GetById(string productCode);


        Task<bool> Delete(string id);
    }
}