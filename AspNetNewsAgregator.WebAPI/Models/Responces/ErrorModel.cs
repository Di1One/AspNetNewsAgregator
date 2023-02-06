namespace AspNetNewsAgregator.WebAPI.Models.Responces;

/// <summary>
/// Model for returning errors from API
/// </summary>
public class ErrorModel
{
    /// <summary>
    /// Error message
    /// </summary>
    public string? Message { get; set; }
}