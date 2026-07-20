namespace Contact_Management.DTOs;

public class AuthResponseDTO
{
    public bool Success { get; set; }

    public string Message { get; set; } 

    public string? Token { get; set; }

    public object? User { get; set; }
}