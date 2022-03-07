using azlearn_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace azlearn_app.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost("create")]
    public IActionResult Create(){
        var response = new CreateAccountResponse();

        response.AccountUId = Guid.NewGuid().ToString();

        var rand = new Random();
        var bin = "545910";
        var productCode = "30";
        var branchCode = "01";
        var randNumber = rand.Next(100000, 999999);
        string number = $"{bin}{productCode}{branchCode}{randNumber.ToString("D6")}";
        var accountNumber = long.Parse(number);
        response.AccountNumber = accountNumber;

        response.AccountHolderName = Faker.Name.FullName();
        response.AccountType = AccountType.checking;
        
        return Ok(response);
    }
}