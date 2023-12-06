using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vulnerableaspnetcoreapp.Pages;

public class ImagePreviewModel : PageModel
{
    private readonly ILogger<ImagePreviewModel> _logger;
    public string? Source { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? UnvalidatedFileName { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? AllowlistedFileName { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? FileName { get; set; }

    public ImagePreviewModel(ILogger<ImagePreviewModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        if (UnvalidatedFileName != null)
        {
            Source = DangerouslyFetchDataURLFromFilename(UnvalidatedFileName);
        }
        else if (AllowlistedFileName != null)
        {
            Source = FetchAllowlistedDataURLFromFileName(AllowlistedFileName);
        }
        else if (FileName != null)
        {
            Source = FetchValidatedDataURLFromFileName(FileName);
        }
    }

    private string DangerouslyFetchDataURLFromFilename(string fileName)
    {
        return FetchImageDataURLFromPath(Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", fileName]));
    }

    private string FetchAllowlistedDataURLFromFileName(string fileName)
    {
        string[] allowedFiles = ["hardhat.jpg"];
        return allowedFiles.Contains(fileName) ? FetchImageDataURLFromPath(Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", fileName])) : "";
    }

    private string FetchValidatedDataURLFromFileName(string fileName)
    {
        var sanitizedFileName = Path.GetFileName(fileName);
        var expectedPath = Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images"]);
        var expectedExtension = ".jpg";
        var fullPath = Path.Combine(expectedPath, sanitizedFileName);
        return Path.GetDirectoryName(fullPath) == expectedPath && Path.GetExtension(fullPath) == expectedExtension ? FetchImageDataURLFromPath(fullPath) : "";
    }

    private string FetchImageDataURLFromPath(string path)
    {
        byte[] fileBytes = System.IO.File.ReadAllBytes(path);
        string base64EncodedData = Convert.ToBase64String(fileBytes);
        return string.Format("data:image/png;base64,{0}", base64EncodedData);
    }
}



