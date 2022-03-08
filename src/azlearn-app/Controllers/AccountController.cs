using azlearn_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace azlearn_app.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost("create")]
    public IActionResult Create(){
        var response = new CreateAccountResponse{
            AccountUId = Guid.NewGuid().ToString(),
            AccountNumber = GetAccountNumber(),
            AccountHolderName = Faker.Name.FullName(),
            AccountType = AccountType.checking
        };
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
}