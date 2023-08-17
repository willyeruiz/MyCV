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

    public StudyId Id { get;  set; }

    public  string Campus { get;  set; } = string.Empty;

    public string City { get;  set; } = string.Empty;

    public string Country { get;  set; } = string.Empty;

    public string Name { get;  set; } = string.Empty;
}
