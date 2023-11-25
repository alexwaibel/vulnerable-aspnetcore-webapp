using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vulnerableaspnetcoreapp.Pages;

public class DirectoryTraversalModel : PageModel
{
    private readonly ILogger<DirectoryTraversalModel> _logger;

    public DirectoryTraversalModel(ILogger<DirectoryTraversalModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

