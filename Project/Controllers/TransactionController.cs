using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Commands;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionsService;
        private readonly ICategoryService _categoriesService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionsService, ICategoryService categoriesService, IMapper mapper)
        {
            _transactionsService = transactionsService;
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        // api/transaction/ImportTransactions
        [HttpPost("[action]")]
        public async Task<IActionResult> ImportTransactions()
        {
            var request = HttpContext.Request;
            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            var status = await _transactionsService.AddTransactions(request);
            if (status) return StatusCode(201);

            return BadRequest("Error while inserting the transactions");
        }

        // api/transaction/update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(TransactionCommand transactionsCommand)
        {
            var status = await _transactionsService.UpdateTransactions(transactionsCommand);
            if (status) return StatusCode(200, transactionsCommand);

            return BadRequest("Error while updating the entity");
        }

        // api/transaction/delete/{id}
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var status = await _transactionsService.DeleteTransactions(id);
            if (status) return Ok("Delete ok");

            return BadRequest("Error while deleting the entity");
        }

        // api/transaction/{id}/split
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Split([FromQuery] SplitParametars SpltParametars)
        {
            return Ok();
        }

        // api/transaction/{id}/categorize
        [HttpPost("[action]")]
        public async Task<IActionResult> Categorize([FromQuery] SplitParametars SplitParametars)
        {
            if (SplitParametars.Id == null)
            {
                return BadRequest("Transaction Id invalid");
            }
            else if (SplitParametars.CategoryId == null)
            {
                return BadRequest("Category Id invalid");
            }

            Task<Transactions> updatedTransaction = _transactionsService.GetTransactionById(SplitParametars.TranscationId);

            if (updatedTransaction == null)
            {
                return BadRequest("Transcation was not found in Database");
            }


            TransactionCommand transactionsCommand = new TransactionCommand
            {
                Amount = (float)updatedTransaction.Result.Amount,
                benName = updatedTransaction.Result.benName,
                Currency = updatedTransaction.Result.Currency,
                TransactionDate= updatedTransaction.Result.Date,
                Description = updatedTransaction.Result.Description,
                Direction = updatedTransaction.Result.Direction,
                Id = updatedTransaction.Result.Id,
                Kind = updatedTransaction.Result.Kind,
                Mcc = updatedTransaction.Result.Mcc,
            };

            await _transactionsService.UpdateTransactions(transactionsCommand);
            return Ok(transactionsCommand);
        }

        // api/transaction/autocategorize
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AutoCategorize(int TransactionId)
        {
            return Ok();
        }

        //  api/spending-analytics
        [HttpGet("[action]")]
        public async Task<IActionResult> SpendingAnalytics(string CategoryCode, string StartDate, string EndDate, string direction)
        {

            return Ok();
     
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTransactions([FromQuery] QueryParams TransactionsParams)
        {
            var status = await _transactionsService.GetPagedListTransactions(TransactionsParams);

            Response.AddPagination(status.CurrentPage, status.PageSize, status.TotalCount, status.TotalPages);

            return Ok(_mapper.Map<List<TransactionsDto>>(status));
        }
    }

}