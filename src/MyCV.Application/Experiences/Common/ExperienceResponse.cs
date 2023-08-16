
using MyCV.Domain.Identificators;

public record ExperienceResponse(
         Guid Id,
         string Company,
         string From,
         string To,
         string Position,
        string Description
);