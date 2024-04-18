namespace WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public AccountBasicInfo? Basic {  get; set; }

    public AccountAdressInfo? Adress { get; set; }
}

public class AccountBasicInfo
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Bio { get; set; }
}

public class AccountAdressInfo
{

    public string AdressLine_1 { get; set; } = null!;

    public string? AdressLine_2 { get; set; }

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;
}