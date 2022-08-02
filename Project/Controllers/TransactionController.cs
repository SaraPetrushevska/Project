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
        private readonly ILogger<TransactionController> _logger;


        public TransactionController(ITransactionService transactionsService, ICategoryService categoriesService, IMapper mapper, 
            ILogger<TransactionController> logger)
        {
            _transactionsService = transactionsService;
            _categoriesService = categoriesService;
            _mapper = mapper;
            _logger = logger;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of products", page);
            var result = await _transactionsService.GetTransactions(page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
        }

        [HttpGet("{productCode}")]
        public async Task<IActionResult> GetTransaction(string Id)
        {
            var product = await _transactionsService.GetTransactionById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCommand transaction)
        {
            var result = await _transactionsService.AddTransactions(transaction);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{productCode}")]
        public async Task<IActionResult> DeleteTrasaction([FromRoute] string Id)
        {
            var result = await _transactionsService.DeleteTransactions(Id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

    }

}