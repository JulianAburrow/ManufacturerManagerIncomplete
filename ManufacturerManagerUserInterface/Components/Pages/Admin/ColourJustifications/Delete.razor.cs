﻿namespace ManufacturerManagerUserInterface.Components.Pages.Admin.ColourJustifications;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationQueryHandler.GetColourJustificationAsync(ColourJustificationId);
        MainLayout.SetHeaderValue("Delete Colour Justification");
        OkToDelete = ColourJustificationModel.Widgets.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }


    private async Task DeleteColourJustification()
    {
        try
        {
            await ColourJustificationCommandHandler.DeleteColourJustificationAsync(ColourJustificationId, true);
            Snackbar.Add($"Colour Justification {ColourJustificationModel.Justification} successfully deleted.", Severity.Success);
            NavigationManager.NavigateTo("/colourjustifications/index");
        }
        catch (Exception ex)
        {
            Snackbar.Add($"An error occurred deleting Colour Justification {ColourJustificationModel.Justification}. PLease try again.", Severity.Error);
            await ErrorCommandHandler.CreateErrorAsync(ex, true);
        }
    }
}
