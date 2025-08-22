﻿namespace ManufacturerManagerUserInterface.Components.Pages.Admin.Colours;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Colour");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }


    private async Task CreateColour()
    {
        CopyDisplayModelToModel();

        try
        {
            await ColourCommandHandler.CreateColourAsync(ColourModel, true);
            Snackbar.Add($"Colour {ColourModel.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo("/colours/index");
        }
        catch (Exception ex)
        {
            Snackbar.Add($"An error occurred creating colour {ColourModel.Name}. Please try again.", Severity.Error);
            await ErrorCommandHandler.CreateErrorAsync(ex, true);
        }
    }
}
