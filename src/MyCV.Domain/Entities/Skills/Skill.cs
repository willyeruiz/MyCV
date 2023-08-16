using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;

namespace MyCV.Domain.Entities{

public sealed class Skill: AggregateRoot
{
    public Skill() {}

    public Skill(SkillId id, string name, string level, string type, int percentage)
    {
        Id = id;
        Name = name;
        Level = level;
        Type = type;
        Percentage = percentage;
    }
    
    public SkillId Id { get; private set; } 

    public string Name { get; private set; } = string.Empty;
    
    public string Level { get; private set; } = string.Empty;

    public string Type { get; private set; } = string.Empty;

    public int Percentage { get; private set; } = 0;
            
}


}
