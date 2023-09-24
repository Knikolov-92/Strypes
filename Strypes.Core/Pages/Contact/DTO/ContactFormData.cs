namespace Strypes.Core.Pages.Contact.DTO;
public record ContactFormData
(
    string? FirstName,
    string? LastName,
    string? Email,
    string? CompanyName,
    string? Message,
    bool AgreeWithPolicy,
    bool Subscribe
);
