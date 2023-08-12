using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MyCV.Application.Experiences.Create
{
    public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
    {
        public CreateExperienceCommandValidator(){ 
            RuleFor(x => x.Position)
                .NotEmpty()
                .WithMessage("Position is required")
                .MaximumLength(50)
                .WithMessage("Position must not exceed 50 characters");

            RuleFor(x => x.Company)
                .NotEmpty()
                .WithMessage("Company is required")
                .MaximumLength(50)
                .WithMessage("Company must not exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters");

            RuleFor(x => x.From)
                .NotEmpty()
                .WithMessage("Start date is required");

            RuleFor(x => x.To)
                .NotEmpty()
                .WithMessage("End date is required")
                .GreaterThan(x => x.From)
                .WithMessage("End date must be greater than start date");
            
            
         }
    }
}