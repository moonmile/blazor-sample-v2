namespace BlazorMauiCameraApp;
public class ScannerService
{
    public async Task<string?> ShowScannerAsync()
    {
        var tcs = new TaskCompletionSource<string?>();
        var page = new QRCodePage(tcs);
        await Application.Current!.Windows[0].Navigation.PushModalAsync(page);
        return await tcs.Task;
    }
}
