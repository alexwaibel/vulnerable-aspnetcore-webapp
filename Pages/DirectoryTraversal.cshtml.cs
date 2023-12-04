using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vulnerableaspnetcoreapp.Pages;

public class DirectoryTraversalModel : PageModel
{
    private readonly ILogger<DirectoryTraversalModel> _logger;
    public string? DangerousFileContent { get; private set; }

    public DirectoryTraversalModel(ILogger<DirectoryTraversalModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(string fileName = "danger.jpg")
    {
        var fullPath = Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", fileName]);
        byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
        string base64EncodedData = Convert.ToBase64String(fileBytes);
        string imgDataURL = string.Format("data:image/png;base64,{0}", base64EncodedData);
        DangerousFileContent = imgDataURL;
    }
}

