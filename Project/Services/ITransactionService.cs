using Microsoft.AspNetCore.Http;
using Project.Database.Entities;
using Project.Commands;
using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface ITransactionService
    {
        Task<Transaction> AddTransactions(TransactionCommand transactionsCommand);
        Task<Transaction> GetTransactionById(string Id);
        Task<bool> DeleteTransactions(string id);
        Task<TransactionEntity> UpdateTransactions(TransactionCommand transactionsCommand);
        Task<PagedSortedList<Models.Transaction>> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        Task<ICollection<TransactionCommand>> GetAllTransactions();
    }
}