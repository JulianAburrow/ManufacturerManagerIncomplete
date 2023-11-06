namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public abstract class ColourJustificationBasePageClass : BasePageClass
{
    [Inject] protected IColourJustificationHandler ColourJustificationHandler { get; set; } = default!;

    [Parameter] public int ColourJustificationId { get; set; }

    protected ColourJustificationModel ColourJustificationModel { get; set; } = default!;

    protected ColourJustificationDisplayModel ColourJustificationDisplayModel { get; set; } = default!;
}
