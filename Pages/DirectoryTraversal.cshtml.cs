using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vulnerableaspnetcoreapp.Pages;

public class DirectoryTraversalModel : PageModel
{
    private readonly ILogger<DirectoryTraversalModel> _logger;
    public string? DangerousFileContent { get; private set; }
    [BindProperty(SupportsGet = true)]
    public string FileName { get; set; }

    public DirectoryTraversalModel(ILogger<DirectoryTraversalModel> logger)
    {
        _logger = logger;
        FileName = "danger.jpg";
    }

    public void OnGet()
    {
        var fullPath = Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", FileName]);
        DangerousFileContent = this.FetchImageDataURLFromPath(fullPath);
    }

    private string FetchImageDataURLFromPath(string path)
    {
        byte[] fileBytes = System.IO.File.ReadAllBytes(path);
        string base64EncodedData = Convert.ToBase64String(fileBytes);
        return string.Format("data:image/png;base64,{0}", base64EncodedData);
    }
}

