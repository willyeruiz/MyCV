using ErrorOr;

namespace MyCV.Domain.Entities.DomainErrors
{
    public static partial class Errors{
        
        
        public static class Skill
        {
            public static Error NothingToReturn => Error.NotFound("Skill.NotFound","There aren't data to return");


        }
    }
}