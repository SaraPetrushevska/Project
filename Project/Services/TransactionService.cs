using AutoMapper;
using Project.Commands;
using Project.Database.Entities;
using Project.Database.Repositories;
using Project.Models;

namespace Project.Services
{
    public class TransactionService : ITransactionService
    {
        Task<bool> ITransactionService.AddTransactions(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITransactionService.DeleteTransactions(string id)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TransactionCommand>> ITransactionService.GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        Task<PagedSortedList<Transaction>> ITransactionService.GetProducts(int page, int pageSize, string sortBy, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        Task<Transaction> ITransactionService.GetTransactionById(string Id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITransactionService.UpdateTransactions(TransactionCommand transactionsCommand)
        {
            throw new NotImplementedException();
        }
    }
}