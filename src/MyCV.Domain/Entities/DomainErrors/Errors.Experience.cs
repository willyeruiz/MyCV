using ErrorOr;

namespace MyCV.Domain.Entities.DomainErrors
{
    public static partial class Errors{
        
        
        public static class Experience
        {
            public static Error CompanyValidation => Error.Validation("Experience.Company","Company name is required or is not valid");

            public static Error ShortDescriptionValidation => Error.Validation("Experience.Description","Description is too short");

            public static Error LongDescriptionValidation => Error.Validation("Experience.Description","Description is too long");

            public static Error NothingToReturn => Error.NotFound("Experience.NotFound","There aren't data to return");
            
            public static Error CreatingError => Error.NotFound("Experience.Creating","Error while creating new Experience");
        }
    }
}