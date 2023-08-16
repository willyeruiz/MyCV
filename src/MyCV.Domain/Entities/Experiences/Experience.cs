using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;

namespace MyCV.Domain.Entities{
    
    public class Experience : AggregateRoot
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
        
        public ExperienceId Id { get;  set; } 
        public string Company { get;  set; } = string.Empty;
        public string From { get;  set; } = string.Empty;
        public string To { get;  set; } = string.Empty;
        public string Position { get;  set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        
    }

     public class ExperienceSimple 
    {   
        public ExperienceSimple(){}

      
        public Guid Id { get;  set; }
        public string Company { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        
    }


}