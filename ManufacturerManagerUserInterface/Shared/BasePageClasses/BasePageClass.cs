namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public abstract class BasePageClass : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected ISnackbar Snackbar { get; set; } = default!;
}
