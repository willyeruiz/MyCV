using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;

namespace MyCV.Domain.Entities{



    public sealed class Experience : AggregateRoot
    {   
        public Experience(){}

        public Experience(ExperienceId id, string company, string from, string to, string position, string description)
        {
            Id = id;
            Company = company;
            From = from;
            To = to;
            Position = position;
            Description = description;
        }
        
        public ExperienceId Id { get; private set; } 
        public string Company { get; private set; } = string.Empty;
        public string From { get; private set; } = string.Empty;
        public string To { get; private set; } = string.Empty;
        public string Position { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        
    }


}