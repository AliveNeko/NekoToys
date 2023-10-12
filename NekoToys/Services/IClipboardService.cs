using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace NekoToys.Services;

public interface IClipboardService
{
    ValueTask CopyTextToClipboard(string text);
    ValueTask<string> PasteTextFromClipboard();
}

public class ClipboardService : IClipboardService
{
    private readonly IJSRuntime _jsRuntime;
    
    public ClipboardService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async ValueTask CopyTextToClipboard(string text)
    {
        await _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }

    public async ValueTask<string> PasteTextFromClipboard()
    {
        return await _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
    }
}