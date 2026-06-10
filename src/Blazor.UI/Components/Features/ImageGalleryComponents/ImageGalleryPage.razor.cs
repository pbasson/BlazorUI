namespace Blazor.UI.Components.Features.ImageGalleryComponents;

public partial class ImageGalleryPage
{
    [Inject]
    ImageGalleryService Services { get; set; } = default!;

    [Inject]
    ToastService ToastService { get; set; } = default!;

    ImageGallerySettings DataSource = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) { return; }

        ToastService.Notify(new(ToastType.Info, "Loading ImageGallery..."));
        DataSource.Load();
        var result = await Services.GetAllRecordsAsync();
        DataSource.DataSet = result.Records ?? [];

        DataSource.Unload();

        ToastService.Notify(new(DataSource.HasRecords ? ToastType.Success : ToastType.Warning, 
            DataSource.HasRecords ? "ImageGallery: Loaded." : "ImageGallery: No ImageGallery found."));

        StateHasChanged();

    }
}