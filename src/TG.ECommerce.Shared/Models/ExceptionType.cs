namespace TG.ECommerce.Shared.Models;

public enum ExceptionType
{
    ValidationException,
    ApplicationException,
    DomainException,
    DbException,
    UnhandledException,
    MappingException,
    UnauthorizedAccessException,
    AuthenticationException
}