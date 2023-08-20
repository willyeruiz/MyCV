using ErrorOr;

namespace MyCV.Domain.Entities.DomainErrors
{
    public static partial class Errors{
        
        
        public static class Study
        {
            public static Error NothingToReturn => Error.NotFound("Study.NotFound","There aren't data to return");


        }
    }
}