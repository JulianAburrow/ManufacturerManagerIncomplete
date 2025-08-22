namespace ManufacturerManagerUserInterface.Components.Pages.Manufacturers;

public partial class Index
{
    protected List<ManufacturerModel> Manufacturers { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Manufacturers = await ManufacturerQueryHandler.GetManufacturersAsync();
        Snackbar.Add($"{Manufacturers.Count} item(s) found.", Manufacturers.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue("Manufacturers");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(true),
        ]);
    }
}