using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vulnerableaspnetcoreapp.Pages;

public class DirectoryTraversalModel : PageModel
{
    private readonly ILogger<DirectoryTraversalModel> _logger;
    public string? DangerousFileContent { get; private set; }
    [BindProperty(SupportsGet = true)]
    public string DangerousFileNameInput { get; set; }
    [BindProperty(SupportsGet = true)]
    public string AllowlistedFileNameInput { get; set; }
    public string? AllowlistedFileContent { get; private set; }

    public DirectoryTraversalModel(ILogger<DirectoryTraversalModel> logger)
    {
        _logger = logger;
        DangerousFileNameInput = "danger.jpg";
        AllowlistedFileNameInput = "hardhat.jpg";
    }

    public void OnGet()
    {
        DangerousFileContent = DangerouslyFetchDataURLFromFilenameInput(DangerousFileNameInput);
        AllowlistedFileContent = FetchAllowlistedDataURLFromPath(AllowlistedFileNameInput);
    }

    private string DangerouslyFetchDataURLFromFilenameInput(string filename)
    {
        return this.FetchImageDataURLFromPath(Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", DangerousFileNameInput]));
    }

    private string FetchAllowlistedDataURLFromPath(string path)
    {
        string[] allowedFiles = ["danger.jpg", "hardhat.jpg"];
        return allowedFiles.Contains(path) ? FetchImageDataURLFromPath(Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", path])) : "";
    }

    private string FetchImageDataURLFromPath(string path)
    {
        byte[] fileBytes = System.IO.File.ReadAllBytes(path);
        string base64EncodedData = Convert.ToBase64String(fileBytes);
        return string.Format("data:image/png;base64,{0}", base64EncodedData);
    }
}

