using AutoMapper;
using Project.Commands;
using Project.Database.Entities;
using Project.Database.Repositories;
using Project.Models;

namespace Project.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionsRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }
        public async Task<Models.Transaction> AddTransactions(TransactionCommand command)
        {
            var entity = _mapper.Map<TransactionEntity>(command);

            var existingProduct = await _transactionsRepository.GetById(command.Id);
            if (existingProduct != null)
            {
                return null;
            }
            var result = await _transactionsRepository.Create(entity);

            return _mapper.Map<Models.Transaction>(result);
        }

        public async Task<bool> DeleteTransactions(string Id)
        {
            return await _transactionsRepository.Delete(Id);
        }

        public async Task<Models.Transaction> GetTransactionById(string Id)
        {
            var transactionEntity = await _transactionsRepository.GetById(Id);

            if (transactionEntity == null)
            {
                return null;
            }

            return _mapper.Map<Models.Transaction>(transactionEntity);
        }

        public async Task<PagedSortedList<Models.Transaction>> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var result = await _transactionsRepository.List(page, pageSize, sortBy, sortOrder);

            return _mapper.Map<PagedSortedList<Models.Transaction>>(result);
        }

        public async Task<ICollection<TransactionCommand>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionEntity> UpdateTransactions(TransactionCommand transactionsCommand)
        {
            throw new NotImplementedException();
        }
    }
}