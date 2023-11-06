namespace ManufacturerManagerUserInterface.Features.Colours;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ColourModel = await ColourHandler.GetColourAsync(ColourId);
        ColourDisplayModel = new ColourDisplayModel
        {
            ColourId = ColourId,
            Name = ColourModel.Name,
        };
    }

    protected async Task UpdateColour()
    {
        ColourModel.ColourId = ColourId;
        ColourModel.Name = ColourDisplayModel.Name;

        try
        {
            await ColourHandler.UpdateColourAsync(ColourModel, true);
            Snackbar.Add($"Colour {ColourModel.Name} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/colours/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating colour {ColourModel.Name}. Please try again.", Severity.Error);
        }
    }
}
