namespace MyCV.Domain;
public class Experience
{
    public int Id { get; set; } = string.Empty.GetHashCode();
    public string Company { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
}
