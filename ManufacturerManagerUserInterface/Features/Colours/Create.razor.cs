namespace ManufacturerManagerUserInterface.Features.Colours;

public partial class Create
{
    protected override void OnInitialized() =>
        ColourDisplayModel = new ColourDisplayModel();

    protected async Task CreateColour()
    {
        ColourModel = new ColourModel
        {
            Name = ColourDisplayModel.Name,
        };

        try
        {
            await ColourHandler.CreateColourAsync(ColourModel, true);
            Snackbar.Add($"Colour {ColourModel.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo("/colours/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating Colour {ColourModel.Name}. Please try again", Severity.Error);
        }
    }
}
