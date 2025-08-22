﻿namespace ManufacturerManagerUserInterface.Components.Pages.Admin.ColourJustifications;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationQueryHandler.GetColourJustificationAsync(ColourJustificationId);
        MainLayout.SetHeaderValue("View Colour Justification");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}
