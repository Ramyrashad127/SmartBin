using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartBin.Models;
using SmartBin.ModelViews;
using SmartBin.Services;

namespace SmartBin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly UserManager<AppUser> _userManager;

        public TransactionController(ITransactionService transactionService, UserManager<AppUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        [HttpGet("SmartBin/{BinId}/page/{PageNumber}")]
        [Authorize]
        public async Task<ActionResult<List<TransactionResultMV>>> GetAllTransactions([FromRoute]int BinId, [FromRoute]int PageNumber, int PageSize = 10)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();
            var transactions = await _transactionService.GetAllTransaction(BinId, user, PageNumber, PageSize);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction([FromForm] TransactionInsertMV transaction, [FromHeader(Name = "Token")]string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _transactionService.AddTransactionAsync(transaction, token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
