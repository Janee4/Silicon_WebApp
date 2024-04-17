using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ProfileImage { get; set; } = "avtar.jpg";

    public string Bio {  get; set; } 

    public int? AdressId { get; set; }  

    public AdressEntity? Adress { get; set; }

}

public class AdressEntity
{
    public int Id { get; set; }

    public string AdressLine_1 { get; set; } = null!;

    public string AdressLine_2 { get; set; }

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;


}
