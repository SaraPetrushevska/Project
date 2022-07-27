using AutoMapper;
using Project.Commands;
using Project.Database.Entities;
using Project.Database.Repositories;
using Project.Models;

namespace Project.Services
{
    public class TransactionsService : ITransactionService
    {
        private readonly ITransactionRepository _transactionsRepository;
        private readonly IMapper _mapper;

        public TransactionsService(ITransactionRepository transactionsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _transactionsRepository = transactionsRepository;
        }


        public async Task<bool> AddTransactions(HttpRequest request)
        {

           
        }

        public async Task<bool> DeleteTransactions(string id)
        {
            return await _transactionsRepository.Delete(id);
        }
        public async Task<bool> UpdateTransactions(TransactionsDto transactionsDto)
        {
            var dataFromDb = await _transactionsRepository.GetById(transactionsDto.Id); // zemi go od baza preku ID

            if (dataFromDb != null)
            {

                dataFromDb.BenificaryName = transactionsDto.BenificaryName;
                dataFromDb.CategoryCode = transactionsDto.CategoryCode;
                _transactionsRepository.Update(dataFromDb);

                if (await _transactionsRepository.SaveAll())
                {
                    //await _loggerService.CreationLog($"Updated Transaction with id: {transactionsDto.Id}",
                    //    "With method: UpdateTransactions ", user, ip, browser);
                    return true;
                }
            }

            return false;
        }
        public async Task<PagedList<Transactions>> GetPagedListTransactions(QueryParams transactionsParams)
        {
            var query = _transactionsRepository.AsQueryable();
            query = query.OrderBy(x => x.BenificaryName);

            // filtriranje po datum
            var dateFrom = Convert.ToDateTime(transactionsParams.FromDate);
            var dateTo = Convert.ToDateTime(transactionsParams.ToDate);
            if (dateFrom <= dateTo) query = query.Where(x => (DateTime)(object)x.Date >= dateFrom && (DateTime)(object)x.Date <= dateTo);

            return await PagedList<Transactions>.ToPagedList(query, transactionsParams.PageNumber, transactionsParams.PageSize);
        }
        public async Task<ICollection<TransactionsDto>> GetAllTransactions()
        {
            // bez paginacija

            //var dataFromDb = await _transactionsRepository.AsQueryable()
            //    .Where(x => x.DeletedBy == null && x.DeletedBy == null)
            //    .ToListAsync();

            return null; /*_mapper.Map<ICollection<TransactionsDto>>(dataFromDb);*/

        }

        public async Task<Transaction> GetTransactionById(string Id)
        {
            Transaction transaction = await _transactionsRepository.GetById(Id);

            return transaction;
        }
    }
}