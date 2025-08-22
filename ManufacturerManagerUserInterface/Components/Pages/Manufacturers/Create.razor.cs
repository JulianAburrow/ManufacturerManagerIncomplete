namespace ManufacturerManagerUserInterface.Components.Pages.Manufacturers;

public partial class Create
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerStatuses = await ManufacturerStatusQueryHandler.GetManufacturerStatusesAsync();
        ManufacturerStatuses.Insert(0, new ManufacturerStatusModel
        {
            StatusId = SharedValues.PleaseSelectValue,
            StatusName = SharedValues.PleaseSelectText,
        });
        ManufacturerDisplayModel.StatusId = -1;
        MainLayout.SetHeaderValue("Create Manufacturer");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb)
        ]);
    }

    private async Task CreateManufacturer()
    {
        try
        {
            CopyDisplayModelToModel();
            await ManufacturerCommandHandler.CreateManufacturerAsync(ManufacturerModel, true);
            Snackbar.Add($"Manufacturer {ManufacturerModel.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo("/manufacturers/index");
        }
        catch (Exception ex)
        {
            Snackbar.Add($"An error occurred creating manufacturer {ManufacturerModel.Name}. Please try again.", Severity.Error);
            await ErrorCommandHandler.CreateErrorAsync(ex, true);
        }
    }
}