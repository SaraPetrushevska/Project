using Microsoft.EntityFrameworkCore;
using Project.Database;
using Project.Database.Entities;
using Project.Models;
using Project.Database.Repositories;

namespace Project.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ProjectDbContext _dbContext;

        public TransactionRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionEntity> Create(TransactionEntity transaction)
        {
            _dbContext.Transactions.Add(transaction);

            await _dbContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<bool> Delete(string id)
        {
            var transaction = await GetById(id);

            if (transaction == null)
            {
                return false;
            }

            _dbContext.Remove(transaction);
            await _dbContext.SaveChangesAsync();
            return true;
        }



        public Task<TransactionEntity> GetById(string productCode)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var query = _dbContext.Transactions.AsQueryable();

            var totalCount = query.Count();

            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "id":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
                        break;
                    case "mcc":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Mcc) : query.OrderByDescending(x => x.Mcc);
                        break;
                    default:
                    case "Kind":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.TransactionKind) : query.OrderByDescending(x => x.TransactionKind);
                        break;
                }
            }
          

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new PagedSortedList<TransactionEntity>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }

        Task<TransactionEntity> ITransactionRepository.Update(TransactionEntity transaction)
        {
            throw new NotImplementedException();
        }
    }
}
