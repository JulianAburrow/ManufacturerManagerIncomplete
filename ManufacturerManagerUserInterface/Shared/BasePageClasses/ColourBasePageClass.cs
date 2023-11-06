namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public abstract class ColourBasePageClass : BasePageClass
{
    [Inject] protected IColourHandler ColourHandler { get; set; } = default!;

    [Parameter] public int ColourId { get; set; }

    protected ColourModel ColourModel { get; set; } = default!;

    protected ColourDisplayModel ColourDisplayModel { get; set; } = default!;
}
