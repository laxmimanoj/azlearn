using azlearn_app.Models;
using azlearn_app.ServiceBus;
using Microsoft.AspNetCore.Mvc;

namespace azlearn_app.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly AzLearnSender _sender;
    public AccountController(IConfiguration configuration, AzLearnSender sender)
    {
        _configuration = configuration;
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(){
        //create account
        var response = new CreateAccountResponse{
            AccountUId = Guid.NewGuid().ToString(),
            AccountNumber = GetAccountNumber(),
            AccountHolderName = Faker.Name.FullName(),
            AccountType = AccountType.checking
        };
        //send to queue
        await SendToQueue(response);
        return Ok(response);
    }

    public long GetAccountNumber(){
        var rand = new Random();
        var bin = "545910";
        var productCode = "30";
        var branchCode = "01";
        var randNumber = rand.Next(100000, 999999);
        string number = $"{bin}{productCode}{branchCode}{randNumber.ToString("D6")}";
        return long.Parse(number);
    }

    public async Task SendToQueue(CreateAccountResponse obj){
       await _sender.SendMessageAsync(obj);
    }
}