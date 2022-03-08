namespace azlearn_app.Models{
    public class CreateAccountResponse{
        public string? AccountUId { get; set; } = "0";
        public long AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public string? AccountHolderName{get;set;} = "";
    }
    public enum AccountType{
        checking = 1,
        savings = 2,
        regularira = 3,
        rothira = 4,
        smallbusiness = 5
    }
}