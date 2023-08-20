using ErrorOr;

namespace MyCV.Domain.Entities.DomainErrors
{
    public static partial class Errors{
        
        
        public static class Profile
        {
            public static Error NothingToReturn => Error.NotFound("Profile.NotFound","There aren't profile data to return");


        }
    }
}