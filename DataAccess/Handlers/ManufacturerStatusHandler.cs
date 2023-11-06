namespace DataAccess.Handlers;

public class ManufacturerStatusHandler : IManufacturerStatusHandler
{
    private readonly ManufacturerManagerContext _context;

    public ManufacturerStatusHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task<List<ManufacturerStatusModel>> GetManufacturerStatusesAsync() =>
        await _context.ManufacturerStatuses.ToListAsync();
}
