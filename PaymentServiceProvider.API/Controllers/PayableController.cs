using Microsoft.AspNetCore.Mvc;
using PaymentServiceProvider.Application.Interfaces.Payable;

namespace PaymentServiceProvider.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PayableController : ControllerBase
{
    private readonly IGetBalancesUseCase _getBalancesUseCase;

    public PayableController(IGetBalancesUseCase getBalancesUseCase)
    {
        _getBalancesUseCase = getBalancesUseCase;
    }

    [HttpGet]
    public IActionResult GetBalances()
    {
        var balanceDto = _getBalancesUseCase.Execute(true);
        return Ok(balanceDto);
    }
}