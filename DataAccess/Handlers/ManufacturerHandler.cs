namespace DataAccess.Handlers;

public class ManufacturerHandler : IManufacturerHandler
{
    private readonly ManufacturerManagerContext _context;

    public ManufacturerHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task CreateManufacturerAsync(ManufacturerModel manufacturer, bool callSaveChanges)
    {
        _context.Manufacturers.Add(manufacturer);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task<ManufacturerModel> GetManufacturerAsync(int manufacturerId) =>
        await _context.Manufacturers
            .Include(m => m.Widgets)
                .ThenInclude(w => w.Colour)
            .Include(m => m.Status)
            .SingleOrDefaultAsync(m => m.ManufacturerId == manufacturerId);

    public async Task<List<ManufacturerModel>> GetManufacturersAsync() =>
        await _context.Manufacturers
            .Include(m => m.Widgets)
            .Include(m => m.Status)
            .ToListAsync();

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateManufacturerAsync(ManufacturerModel manufacturer, bool callSaveChanges)
    {
        var manufacturerToUpdate = _context.Manufacturers
            .Include (m => m.Widgets)
            .SingleOrDefault(m => m.ManufacturerId == manufacturer.ManufacturerId);
        if (manufacturerToUpdate == null)
            return;
        manufacturerToUpdate.Name = manufacturer.Name;
        manufacturerToUpdate.StatusId = manufacturer.StatusId;

        if (manufacturerToUpdate.StatusId == (int) PublicEnums.ManufacturerStatusEnum.Inactive)
        {
            // All of this manufacturers Widgets should now be set to inactive
            foreach (var widget in manufacturerToUpdate.Widgets)
            {
                widget.StatusId = (int) PublicEnums.WidgetStatusEnum.Inactive;
            }
        }

        if (callSaveChanges)
            await SaveChangesAsync();
    }
}
