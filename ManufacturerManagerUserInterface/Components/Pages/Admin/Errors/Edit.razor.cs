using System.Threading.Tasks;

namespace ManufacturerManagerUserInterface.Components.Pages.Admin.Errors;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ErrorModel = await ErrorQueryHandler.GetErrorAsync(ErrorId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Error");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetErrorHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private void SetResolvedDate()
    {
        ErrorDisplayModel.ResolvedDate = ErrorDisplayModel.Resolved
            ? DateTime.Now
            : null;
    }

    private async Task UpdateError()
    {
        CopyDisplayModelToModel();
        try
        {
            await ErrorCommandHandler.UpdateErrorAsync(ErrorModel, true);
            Snackbar.Add($"Error {ErrorModel.ErrorId} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo("/errors/index");
        }
        catch (Exception ex)
        {
            Snackbar.Add($"An error occurred updating error {ErrorModel.ErrorId}. Please try again.", Severity.Error);
            await ErrorCommandHandler.CreateErrorAsync(ex, true);
        }
    }
}