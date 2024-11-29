namespace LibraryManagement.Shared.Models;

public class ErrorDescriptionModel
{
    public int StatusCode { get; set; }

    public string ErrorMessage { get; set; }

    public string Details { get; set; }
}