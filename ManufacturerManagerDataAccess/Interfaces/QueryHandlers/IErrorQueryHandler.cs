namespace ManufacturerManagerDataAccess.Interfaces.QueryHandlers;

public interface IErrorQueryHandler
{
    Task<ErrorModel> GetErrorAsync(int errorId);

    Task<List<ErrorModel>> GetErrorsAsync();
}
