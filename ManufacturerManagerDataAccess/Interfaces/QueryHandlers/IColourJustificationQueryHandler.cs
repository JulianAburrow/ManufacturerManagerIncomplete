namespace ManufacturerManagerDataAccess.Interfaces.QueryHandlers;

public interface IColourJustificationQueryHandler
{
    Task<ColourJustificationModel> GetColourJustificationAsync(int colourJustificationId);

    Task<List<ColourJustificationModel>> GetColourJustificationsAsync();
}
