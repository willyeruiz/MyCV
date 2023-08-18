using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;

namespace MyCV.Domain.Entities;

public sealed class Profile: AggregateRoot
{
    public ProfileId Id { get; set; }
    public string Picture { get; set; } = string.Empty;

    public string Description { get; set;} = string.Empty;

    public string Title {get; set;} = string.Empty;

    public string Email { get; set;} = string.Empty;

    public string Phone {get;set;} = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public Profile(){

    }
    public Profile(ProfileId id, string picture, string description, string title, string email, string phone, string address,string city ){
        Id = id;
        Picture = picture;
        Description = description;
        Title = title;
        Email = email;
        Phone = phone;
        Address = address;
        City = city;
    }
}
