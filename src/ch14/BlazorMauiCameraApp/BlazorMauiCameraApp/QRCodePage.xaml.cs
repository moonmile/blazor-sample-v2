namespace BlazorMauiCameraApp;

using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

public partial class QRCodePage : ContentPage
{
    private TaskCompletionSource<string?> _tcs;
    public QRCodePage(TaskCompletionSource<string?> tcs)
    {
        InitializeComponent();
        _tcs = tcs;
        this.Loaded += (_, _) =>
		{
            cameraBarcodeReaderView.Options = new BarcodeReaderOptions()
			{
				Formats = BarcodeFormat.QrCode
			};
		};
	}

	private void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	{
		var code = e.Results.FirstOrDefault();
		if ( code != null )
		{
			if ( code.Format == BarcodeFormat.QrCode )
			{
                cameraBarcodeReaderView.IsDetecting = false;
                _tcs.TrySetResult(code.Value);
                Dispatcher.Dispatch( async () =>
                {
                    await this.Navigation.PopModalAsync();
                });
            }
		}
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await this.Navigation.PopModalAsync();
    }
}
