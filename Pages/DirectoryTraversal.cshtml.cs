using Microsoft.AspNetCore.Components.Web;
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
    [BindProperty(SupportsGet = true)]
    public string ValidatedFileNameInput { get; set; }
    public string? ValidatedFileContent { get; private set; }

    public DirectoryTraversalModel(ILogger<DirectoryTraversalModel> logger)
    {
        _logger = logger;
        DangerousFileNameInput = "danger.jpg";
        AllowlistedFileNameInput = "hardhat.jpg";
        ValidatedFileNameInput = "hardhat.jpg";
    }

    public void OnGet()
    {
        DangerousFileContent = DangerouslyFetchDataURLFromFilename(DangerousFileNameInput);
        AllowlistedFileContent = FetchAllowlistedDataURLFromFileName(AllowlistedFileNameInput);
        ValidatedFileContent = FetchValidatedDataURLFromFileName(ValidatedFileNameInput);
    }

    private string DangerouslyFetchDataURLFromFilename(string filename)
    {
        return FetchImageDataURLFromPath(Path.Combine([System.IO.Directory.GetCurrentDirectory(), "wwwroot", "images", DangerousFileNameInput]));
    }

    private string FetchAllowlistedDataURLFromFileName(string fileName)
    {
        string[] allowedFiles = ["danger.jpg", "hardhat.jpg"];
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

