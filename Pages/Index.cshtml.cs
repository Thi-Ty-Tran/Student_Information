/* 
    Name:           Thi Ty Tran
    Date Created:   Dec 12, 2024
    Description:    ASP.NET Razor Pages - Final Assignment
    Last modified:  Dec 14, 2024
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalAssignment.Pages
{
    // Class representing the model for the Index page
    public class IndexModel : PageModel
    {
        // Logger for logging information and errors
        private readonly ILogger<IndexModel> _logger;

        // Constructor that initializes the logger
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger; // Assigning the logger to the private field
        }

        // Handler for GET requests to the Index page
        public void OnGet()
        {

        }

    }
}
