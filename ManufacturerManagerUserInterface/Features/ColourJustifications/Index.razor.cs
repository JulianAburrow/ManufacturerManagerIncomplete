namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class Index
{
    private List<ColourJustificationModel> ColourJustifications { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        ColourJustifications = await ColourJustificationHandler.GetColourJustificationsAsync();
        Snackbar.Add($"{ColourJustifications.Count} item(s) found", ColourJustifications.Count == 0 ? Severity.Error : Severity.Success);
    }
}
