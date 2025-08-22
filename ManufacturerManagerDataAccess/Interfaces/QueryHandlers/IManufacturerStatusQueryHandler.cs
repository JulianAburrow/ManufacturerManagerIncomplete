namespace ManufacturerManagerDataAccess.Interfaces.QueryHandlers;

public interface IManufacturerStatusQueryHandler
{
    Task<List<ManufacturerStatusModel>> GetManufacturerStatusesAsync();
}
