using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;

namespace MyCV.Domain.Entities;

public sealed class Study: AggregateRoot
{
    public Study(){}
    
    public Study(StudyId id, string campus, string city, string country, string name)
    {
        Id = id;
        Campus = campus;
        City = city;
        Country = country;
        Name = name;
    }

    public StudyId Id { get; private set; } 

    public  string Campus { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string Country { get; private set; } = string.Empty;
    
    public string Name { get; private set; } = string.Empty;
    
}
