﻿namespace ManufacturerManagerUserInterface.Components.Pages.Admin.ColourJustifications;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationQueryHandler.GetColourJustificationAsync(ColourJustificationId);
        ColourJustificationDisplayModel.Justification = ColourJustificationModel.Justification;
        MainLayout.SetHeaderValue("Edit Colour Justification");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateColourJustification()
    {
        ColourJustificationModel.Justification = ColourJustificationDisplayModel.Justification;

        try
        {
            await ColourJustificationCommandHandler.UpdateColourJustificationAsync(ColourJustificationModel, true);
            Snackbar.Add($"Colour Justification {ColourJustificationModel.Justification} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo("/colourjustifications/index");
        }
        catch (Exception ex)
        {
            Snackbar.Add($"An error occurred updating Colour Justification {ColourJustificationModel.Justification}. Please try again", Severity.Error);
            await ErrorCommandHandler.CreateErrorAsync(ex, true);
        }
    }
}
