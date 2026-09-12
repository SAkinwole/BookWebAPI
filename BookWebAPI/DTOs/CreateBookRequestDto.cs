namespace BookWebAPI.DTOs;

public class CreateBookRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
}
