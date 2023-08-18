
public record ProfileResponse(
        Guid Id,
        string picture, 
        string description, 
        string title, 
        string email, 
        string phone, 
        string address,
        string city
);